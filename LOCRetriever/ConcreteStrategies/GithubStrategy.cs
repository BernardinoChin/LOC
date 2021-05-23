using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOCRetriever
{
    public class GithubStrategy : IRetrieverStrategy
    {
        public string BaseUrl => "https://api.github.com/repos";
        private readonly string UserName;
        private readonly string Password;

        public GithubStrategy(string _UserName, string _Password)
        {
            this.UserName = _UserName;
            this.Password = _Password;
        }

        public List<Branche> GetBranches(string OrganizationIdentifier, string RepositoryIdentifier)
        {
            string ResourceIdentifier = "branches";
            List<Branche> Branches = new List<Branche>();

            RestClient Client = new RestClient(BaseUrl);
            Client.Authenticator = new HttpBasicAuthenticator(this.UserName, this.Password);
            RestRequest Request = new RestRequest(string.Format("{0}/{1}/{2}?per_page=100", OrganizationIdentifier, RepositoryIdentifier, ResourceIdentifier));
            var Response = Client.Execute(Request);


            if (Response.IsSuccessful)
            {
                Branches = JArray.Parse(Response.Content).Select(JSONBranche => new Branche
                {
                    Name = JSONBranche.SelectToken("name").ToString()
                }).ToList();
            }


            return Branches;
        }


        public List<Commit> GetCommits(CommitRequest CommitRequest)
        {
            string ResourceIdentifier = "commits";
            string StrSince = string.Empty;
            string StrUntil = string.Empty;
            List<Commit> Commits = new List<Commit>();


            /*
             * NOTA: Traer toda la información para no realizar una petición por cada requerimiento y rango de fechas.
             */


            if (!string.IsNullOrEmpty(CommitRequest.BrancheIdentifier))
                CommitRequest.BrancheIdentifier = string.Format("&sha={0}", CommitRequest.BrancheIdentifier);


            if (CommitRequest.Since != DateTime.MinValue)
                StrSince = string.Format("&since={0}", CommitRequest.Since.ToString("yyyy-MM-dd:HH:mm:ss"));


            if (CommitRequest.Until != DateTime.MinValue)
                StrUntil = string.Format("&until={0}", CommitRequest.Until.ToString("yyyy-MM-dd:HH:mm:ss"));


            RestClient Client = new RestClient(BaseUrl);
            Client.Authenticator = new HttpBasicAuthenticator(this.UserName, this.Password);


            int CurrentPage = 1;
            bool ContinueIteration = true;
            while (ContinueIteration)
            {
                RestRequest Request = new RestRequest(
                    string.Format("{0}/{1}/{2}?per_page=100&page={3}{4}{5}",
                    CommitRequest.OrganizationIdentifier,
                    CommitRequest.RepositoryIdentifier,
                    ResourceIdentifier,
                    CurrentPage,
                    CommitRequest.BrancheIdentifier,
                    StrSince
                ));
                var Response = Client.Execute(Request);


                if (Response.IsSuccessful)
                {
                    List<Commit> RetrievedCommits = JArray.Parse(Response.Content).Select(JSONCommit => new Commit
                    {
                        CommitId = JSONCommit.SelectToken("sha").ToString(),
                        Author = JSONCommit.SelectToken("commit.author.name").ToString(),
                        Message = JSONCommit.SelectToken("commit.message").ToString(),
                        CreatedDate = DateTime.Parse(JSONCommit.SelectToken("commit.committer.date").ToString())
                    }).ToList();

                    Commits.AddRange(RetrievedCommits);
                    ContinueIteration = RetrievedCommits.Count > 0;
                    CurrentPage++;
                }
                else
                {
                    Console.WriteLine("Error de conexión intentando recuperar la página " + CurrentPage + ". Error:" + Response.Content + ". Reintentando...");
                }
            }

            return Commits;
        }


        public List<CommitFile> GetCommitFiles(CommitFileRequest CommitFileRequest)
        {
            string ResourceIdentifier = "commits";
            List<CommitFile> Files = new List<CommitFile>();


            if (string.IsNullOrEmpty(CommitFileRequest.CommitIdentifier))
                throw new Objects.RetrieverException("Commit identifier not provided");


            RestClient Client = new RestClient(BaseUrl);
            Client.Authenticator = new HttpBasicAuthenticator(this.UserName, this.Password);
            RestRequest Request = new RestRequest(string.Format("{0}/{1}/{2}/{3}", CommitFileRequest.OrganizationIdentifier, CommitFileRequest.RepositoryIdentifier, ResourceIdentifier, CommitFileRequest.CommitIdentifier));
            var Response = Client.Execute(Request);


            if (Response.IsSuccessful)
            {
                Files = JObject.Parse(Response.Content).SelectToken("files").Select(JSONFile => new CommitFile
                {
                    FileId = JSONFile.SelectToken("sha").ToString(),
                    FileName = JSONFile.SelectToken("filename").ToString(),
                    FileExtension = JSONFile.SelectToken("filename").ToString().Substring(JSONFile.SelectToken("filename").ToString().LastIndexOf(".")),
                    AddedLines = int.Parse(JSONFile.SelectToken("additions").ToString()),
                    DeletedLines = int.Parse(JSONFile.SelectToken("deletions").ToString())
                }).ToList();
            }


            return Files;
        }


        public CountResponse _CountLines(CountRequest CountRequest)
        {
            CountResponse Response = new CountResponse();
            List<Commit> Commits = new List<Commit>();
            DateTime BetweenStartDate = new DateTime();
            DateTime BetweenEndDate = new DateTime();

            if (CountRequest.Branches.Count == 0)
            {
                CountRequest.Branches = this.GetBranches(CountRequest.OrganizationIdentifier, CountRequest.RepositoryIdentifier)
                    .Select(Branche => Branche.Name)
                    .ToList();
            }

            BetweenStartDate = GetMinDateInRange(CountRequest.Requirements);
            BetweenEndDate = GetMaxDateInRange(CountRequest.Requirements);
            CountRequest.Branches.ForEach(Branche =>
            {
                Commits.AddRange(GetCommits(new CommitRequest()
                {
                    OrganizationIdentifier = CountRequest.OrganizationIdentifier,
                    RepositoryIdentifier = CountRequest.RepositoryIdentifier,
                    BrancheIdentifier = Branche,
                    Since = BetweenStartDate,
                    Until = BetweenEndDate
                }));
            });


            //Commits Únicos y ordenados por fecha. Aplicar exclusión por descripción.
            Commits = Commits
                .GroupBy(Commit => Commit.CommitId)
                .Select(UniqueCommit => UniqueCommit.First())
                .OrderBy(Commit => Commit.CreatedDate)
                .ToList();
            Commits = ApplyCommitExclusionRules(Commits, CountRequest.CommitIgnore);


            //Sin filtro por requerimientos. 
            if (CountRequest.Requirements.Count == 0)
            {
                CountResponseItem Item = CountLines(
                    CountRequest.OrganizationIdentifier,
                    CountRequest.RepositoryIdentifier,
                    "Todos",
                    Commits.ToList(),
                    CountRequest.FileIgnore
                );
                Response.CountResponseItems.Add(Item);
                return Response;
            }


            //Se se requiere incluir únicamente los commits relacionados a los requerimientos especificados.                
            List<IGrouping<string, Commit>> CommitGroups = Commits.GroupBy(c => GetIdentity(c.Message)).ToList();
            CountRequest.Requirements.ForEach(Requirement =>
            {
                List<Commit> LsCommits = new List<Commit>();
                var Group = CommitGroups.FirstOrDefault(g => g.Key.ToLower() == Requirement.Identifier.ToLower());
                if (Group != null)
                {
                    if (Requirement.DateRange.Count > 0)
                    {
                        Requirement.DateRange.ForEach(dr =>
                       {
                           if (dr.Item1 != DateTime.MinValue && dr.Item2 != DateTime.MinValue)
                           {
                               LsCommits.AddRange(
                                   Group.Where(c => c.CreatedDate >= dr.Item1 && c.CreatedDate <= dr.Item2)
                               );
                           }
                       });
                    }
                    else
                    {
                        LsCommits = Group.ToList();
                    }
                }


                if (LsCommits.Any())
                {
                    CountResponseItem Item = CountLines(
                        CountRequest.OrganizationIdentifier,
                        CountRequest.RepositoryIdentifier,
                        Requirement.Identifier,
                        LsCommits,
                        CountRequest.FileIgnore
                    );
                    Response.CountResponseItems.Add(Item);
                }
                else
                {
                    Response.CountResponseItems.Add(new CountResponseItem()
                    {
                        Requirement = Requirement.Identifier,
                        LinesOfCodeAdded = 0,
                        Commits = new List<CountResponseCommitItem>()
                    });
                }
            });


            return Response;
        }

        public CountResponse CountLines(CountRequest CountRequest)
        {
            CountResponse Response = new CountResponse();
            List<Commit> Commits = new List<Commit>();
            DateTime BetweenStartDate = new DateTime();
            DateTime BetweenEndDate = new DateTime();

            if (CountRequest.Branches.Count == 0)
            {
                CountRequest.Branches = this.GetBranches(CountRequest.OrganizationIdentifier, CountRequest.RepositoryIdentifier)
                    .Select(Branche => Branche.Name)
                    .ToList();
            }


            BetweenStartDate = CountRequest.BetweenStartDate == DateTime.MinValue ? GetMinDateInRange(CountRequest.Requirements) : CountRequest.BetweenStartDate;
            BetweenEndDate = CountRequest.BetweenEndDate == DateTime.MinValue ? GetMaxDateInRange(CountRequest.Requirements) : CountRequest.BetweenEndDate;
            CountRequest.Branches.ForEach(Branche =>
            {
                Commits.AddRange(GetCommits(new CommitRequest()
                {
                    OrganizationIdentifier = CountRequest.OrganizationIdentifier,
                    RepositoryIdentifier = CountRequest.RepositoryIdentifier,
                    BrancheIdentifier = Branche,
                    Since = BetweenStartDate,
                    Until = BetweenEndDate
                }));
            });


            //Commits Únicos y ordenados por fecha. Aplicar exclusión por descripción.
            Commits = Commits
                .GroupBy(Commit => Commit.CommitId)
                .Select(UniqueCommit => UniqueCommit.First())
                .OrderBy(Commit => Commit.CreatedDate)
                .ToList();
            Commits = ApplyCommitExclusionRules(Commits, CountRequest.CommitIgnore);


            //Filtro por fases.
            if (CountRequest.Phases.Count > 0)
            {
                List<Commit> LsCommitsByPhase = new List<Commit>();
                CountRequest.Phases.ForEach(p =>
                {
                    LsCommitsByPhase.AddRange(Commits.Where(c => GetPhase(c.Message) == p));
                });
                Commits = LsCommitsByPhase;
            }


            //Sin filtro por requerimientos. 
            if (CountRequest.Requirements.Count == 0)
            {
                CountResponseItem Item = CountLines(
                    CountRequest.OrganizationIdentifier,
                    CountRequest.RepositoryIdentifier,
                    "Todos",
                    Commits.ToList(),
                    CountRequest.FileIgnore
                );
                Response.CountResponseItems.Add(Item);
                return Response;
            }


            //Se se requiere incluir únicamente los commits relacionados a los requerimientos especificados.                
            List<IGrouping<string, Commit>> CommitGroups = Commits.GroupBy(c => GetIdentity(c.Message)).ToList();
            CountRequest.Requirements.ForEach(Requirement =>
            {
                List<Commit> LsCommits = new List<Commit>();
                var Group = CommitGroups.Where(g => g.Key.ToLower() == Requirement.Identifier.ToLower()).FirstOrDefault();
                if (Group != null)
                {
                    if (Requirement.DateRange.Count > 0)
                    {
                        Requirement.DateRange.ForEach(dr =>
                        {
                            if (dr.Item1 != null && dr.Item2 != null && dr.Item1 != DateTime.MinValue && dr.Item2 != DateTime.MinValue)
                            {
                                LsCommits.AddRange(
                                    Group.ToList().Where(c => c.CreatedDate >= dr.Item1 && c.CreatedDate <= dr.Item2)
                                );
                            }
                        });
                    }
                    else
                    {
                        LsCommits = Group.ToList();
                    }
                }


                if (LsCommits.Count() > 0)
                {
                    CountResponseItem Item = CountLines(
                        CountRequest.OrganizationIdentifier,
                        CountRequest.RepositoryIdentifier,
                        Requirement.Identifier,
                        LsCommits,
                        CountRequest.FileIgnore
                    );
                    Response.CountResponseItems.Add(Item);
                }
                else
                {
                    Response.CountResponseItems.Add(new CountResponseItem()
                    {
                        Requirement = Requirement.Identifier,
                        LinesOfCodeAdded = 0,
                        Commits = new List<CountResponseCommitItem>()
                    });
                }
            });


            return Response;
        }

        public CountResponseItem CountLines(string OrganizationIdentifier, string RepositoryIdentifier, string Requirement, List<Commit> Commits, FileIgnoreObject FileIgnore)
        {
            Commits.ForEach(Commit =>
            {
                List<CommitFile> Files = GetCommitFiles(new CommitFileRequest()
                {
                    OrganizationIdentifier = OrganizationIdentifier,
                    RepositoryIdentifier = RepositoryIdentifier,
                    CommitIdentifier = Commit.CommitId
                });

                Commit.Files = ApplyFileExclusionRules(Files, FileIgnore);
                Commit.AddedLines = Commit.Files.Sum(File => File.AddedLines);
                Commit.DeletedLines = Commit.Files.Sum(File => File.DeletedLines);
            });


            return new CountResponseItem
            {
                Requirement = Requirement,
                Commits = Commits.Select(c => new CountResponseCommitItem
                {
                    CommitId = c.CommitId,
                    Message = c.Message,
                    CreatedAt = c.CreatedDate.ToString()
                }).ToList(),
                LinesOfCodeAdded = Commits.Sum(c => c.AddedLines) - Commits.Sum(c => c.DeletedLines)
            };
        }

        public string GetIdentity(string CommitMesage)
        {
            string[] SplitMessage = CommitMesage.Split(' ');
            string RequirementsSection = SplitMessage[0]; //[ Req20.1,Req20,Req5] Depl...
            string FirstRequirement = RequirementsSection.Split(',')[0]; //[ Req20.1 ], Re...
            string BaseRequirement = FirstRequirement.Split('.')[0]; //[ Req20 ].1 ...

            bool RareCase = !BaseRequirement.Any(char.IsDigit); //[Req] ...
            if (RareCase && SplitMessage.Length > 2)
                BaseRequirement = SplitMessage[0] + SplitMessage[2];

            return BaseRequirement;
        }

        public string GetPhase(string CommitMesage)
        {
            string PhaseSection = "CT|PI|PS|SC|LC";
            string[] SplitMessage = CommitMesage.Split(' ');
            if (SplitMessage.Length > 1)
                PhaseSection = SplitMessage[1]; //[ Req20.1 CT|SC...

            return PhaseSection;
        }

        private List<Commit> ApplyCommitExclusionRules(List<Commit> Commits, CommitIgnoreObject IgnoreObject)
        {
            if (IgnoreObject.CommitExclusionType == ExclusionType.ExcludeThese)
            {
                IgnoreObject.CommitIgnoreList.ForEach(IgnoreCondition =>
                {
                    Commits = Commits.Where(Commit => !Commit.Message.ToLower().Contains(IgnoreCondition.ToLower())).ToList();
                });

            }
            else if (IgnoreObject.CommitExclusionType == ExclusionType.ExcludeAllExceptThese)
            {
                List<Commit> CommitsHelper = new List<Commit>();
                IgnoreObject.CommitIgnoreList.ForEach(IgnoreCondition =>
                {
                    CommitsHelper.AddRange(Commits.Where(Commit => Commit.Message.ToLower().Contains(IgnoreCondition.ToLower())));
                });
                Commits = CommitsHelper;
            }

            return Commits;
        }

        private List<CommitFile> ApplyFileExclusionRules(List<CommitFile> Files, FileIgnoreObject IgnoreObject)
        {
            List<CommitFile> FilterHelper = new List<CommitFile>();
            if (IgnoreObject.FileNameIgnoreList.Count > 0)
            {
                if (IgnoreObject.FileExclusionType == ExclusionType.ExcludeThese)
                {
                    IgnoreObject.FileNameIgnoreList.ForEach(FileName =>
                    {
                        Files = Files.Where(File => !File.FileName.ToLower().Contains(FileName.ToLower())).ToList();
                    });
                }
                if (IgnoreObject.FileExclusionType == ExclusionType.ExcludeAllExceptThese)
                {
                    IgnoreObject.FileNameIgnoreList.ForEach(FileName =>
                    {
                        //impedir que se dupliquen.
                        FilterHelper.AddRange(Files.Where(File => File.FileName.ToLower().Contains(FileName.ToLower())));
                    });
                    Files = FilterHelper;
                }
            }

            FilterHelper = new List<CommitFile>();
            if (IgnoreObject.FileExtensionIgnoreList.Count > 0)
            {
                if (IgnoreObject.FileExclusionType == ExclusionType.ExcludeThese)
                {
                    IgnoreObject.FileExtensionIgnoreList.ForEach(FileExtension =>
                    {
                        Files = Files.Where(File => File.FileExtension.ToLower() != FileExtension.ToLower()).ToList();
                    });
                }
                if (IgnoreObject.FileExclusionType == ExclusionType.ExcludeAllExceptThese)
                {
                    IgnoreObject.FileExtensionIgnoreList.ForEach(FileExtension =>
                    {
                        //impedir que se dupliquen.
                        FilterHelper.AddRange(Files.Where(File => File.FileExtension.ToLower() == FileExtension.ToLower()));
                    });
                    Files = FilterHelper;
                }
            }


            return Files;
        }

        private DateTime GetMinDateInRange(List<Requirement> Requirements)
        {
            DateTime Result = new DateTime();
            var Reqs = Requirements
                .Where(r => r.DateRange != null && r.DateRange.Count > 0);


            var DateRanges = Reqs
                .Select(r => r.DateRange
                    .Where(dr => dr.Item1 != DateTime.MinValue));


            var MinDates = DateRanges
                .Select(ldr => ldr
                    .Select(dr => dr.Item1)
                    .Min()
                );


            if (MinDates.Any())
                Result = MinDates.Min();


            return Result;
        }

        private DateTime GetMaxDateInRange(List<Requirement> Requirements)
        {
            DateTime Result = new DateTime();
            var Reqs = Requirements
                .Where(r => r.DateRange != null && r.DateRange.Count > 0);


            var DateRanges = Reqs
                .Select(req => req.DateRange
                    .Where(dr => dr.Item2 != DateTime.MinValue));


            var MaxDates = DateRanges
                .Select(lsDr => lsDr
                    .Select(dr => dr.Item2)
                    .Max());


            if (MaxDates.Any())
                Result = MaxDates.Max();


            return Result;
        }
    }
}
