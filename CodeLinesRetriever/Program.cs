using LOCRetriever;
using LOCRetriever.Objects;
using System;
using System.Collections.Generic;

namespace CodeLinesRetriever
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Lakeway_CountLines_FilterByDatesPSI();
            }
            catch (RetrieverException exr)
            {
                Console.WriteLine(exr.GetBaseException().Message);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException().Message);
                Console.ReadLine();
            }
        }
        public static void CountLinesBernardinoChin2105()
        {
            /*  
            *  Given: 
            *      Organización    :   bernardinoChin2105.
            *      Repositorio     :   RepositorioLOC.
            *      Branche         :   master, rama2 
            *  When:
            *      Intento contar las líneas de la rama
            *  Then: 
            *      Se deben obtener 31 líneas agregadas y 6 líneas eliminadas. 
           */
            Console.WriteLine("Iniciando Proceso...");
            string Organization = "bernardinoChin2105";
            string Repository = "RepositorioLOC";
            List<string> Branches = new List<string> { "master", "rama2" };
            List<Requirement> Requeriments = new List<Requirement> {
                new Requirement{
                    Identifier= "c1"
                },
                new Requirement{
                    Identifier= "c2"
                },
            };
            string UserName = "BernardinoChin2105";
            string Password = "274a4992cf66627266d6e3a16197ad4724010605";


            Console.WriteLine("Recuperando información...");
            GithubStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            CountResponse Lines = Context.CountLines(new CountRequest()
            {
                OrganizationIdentifier = Organization,
                RepositoryIdentifier = Repository,
                Branches = Branches,
                Requirements = Requeriments
            });


            Printer.PrintResult(Repository, Requeriments, Lines.CountResponseItems);
        }

        public static void El20MX_CountLines()
        {
            Console.WriteLine("Iniciando Proceso...");

            string Organization = "bernardinoChin2105";
            string Repository = "PlataformaEl20mx";
            List<string> Branches = new List<string> { "master", "develop", "ft_req19" };
            List<Requirement> Requeriments = new List<Requirement> {
                new Requirement{
                    Identifier= "Req1"
                },
                new Requirement{
                    Identifier= "Req2"
                },
                new Requirement{
                    Identifier= "Req3"
                },
                new Requirement{
                    Identifier= "Req4"
                },
                new Requirement{
                    Identifier= "Req5"
                },
                new Requirement{
                    Identifier= "Req6"
                },
                new Requirement{
                    Identifier= "Req7"
                },
                new Requirement{
                    Identifier= "Req8"
                },
                new Requirement{
                    Identifier= "Req9"
                },
                new Requirement{
                    Identifier= "Req10"
                },
                new Requirement{
                    Identifier= "Req11"
                },
                new Requirement{
                    Identifier= "Req12"
                },
                new Requirement{
                    Identifier= "Req13"
                },
                new Requirement{
                    Identifier= "Req14"
                },
                new Requirement{
                    Identifier= "Req15"
                },
                new Requirement{
                    Identifier= "Req16"
                },
                new Requirement{
                    Identifier= "Req17"
                },
                new Requirement{
                    Identifier= "Req18"
                },
                new Requirement{
                    Identifier= "Req19"
                },
                new Requirement{
                    Identifier= "Req20"
                },
                new Requirement{
                    Identifier= "Req21"
                },
                new Requirement{
                    Identifier= "Req22"
                }
            };
            string UserName = "bernardinoChin2105";
            string Password = "274a4992cf66627266d6e3a16197ad4724010605";


            Console.WriteLine("Recuperando información del Repositorio " + Repository + "...");
            GithubStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            CountResponse Lines = Context.CountLines(new CountRequest()
            {
                OrganizationIdentifier = Organization,
                RepositoryIdentifier = Repository,
                Branches = Branches,
                Requirements = Requeriments
            });


            Printer.PrintResult(Repository, Requeriments, Lines.CountResponseItems);
        }
        public static void El20MX_CountLines_FilterByDates()
        {
            Console.WriteLine("Iniciando Proceso...");

            string Organization = "BernardinoChin";
            string Repository = "El20MX_RepositorioLOC";
            List<string> Branches = new List<string> { "master", "develop", "ft_req19" };
            List<Requirement> Requeriments = new List<Requirement> {
                new Requirement{
                    Identifier= "Req1",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,05,29), new DateTime(2020, 06, 01).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier= "Req2",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,05,26), new DateTime(2020,06,11).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier= "Req3",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,06,15), new DateTime(2020,06,16).AddDays(1).AddSeconds(-1)),//Sprint 2.                        
                        new Tuple<DateTime, DateTime>(new DateTime(2020,06,18), new DateTime(2020,06,18).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier= "Req4",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,06,13), new DateTime(2020,06,21).AddDays(1).AddSeconds(-1)) //Sprint 2
                    }
                },
                new Requirement{
                    Identifier= "Req5",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,07,22), new DateTime(2020,07,27).AddDays(1).AddSeconds(-1)), //Sprint 4
                        new Tuple<DateTime, DateTime>(new DateTime(2020,08,24), new DateTime(2020,09,01).AddDays(1).AddSeconds(-1)), //Sprint 9
                    }
                },
                new Requirement{
                    Identifier= "Req6",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,05,27), new DateTime(2020,05,29).AddDays(1).AddSeconds(-1)),
                        new Tuple<DateTime, DateTime>(new DateTime(2020,06,19), new DateTime(2020,06,26).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier= "Req7",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,06,26), new DateTime(2020,07,01).AddDays(1).AddSeconds(-1)),
                        new Tuple<DateTime, DateTime>(new DateTime(2020,07,01), new DateTime(2020,07,05).AddDays(1).AddSeconds(-1)),//se excluye el commit del 06-07-2020.
                        new Tuple<DateTime, DateTime>(new DateTime(2020,07,07), new DateTime(2020,07,22).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier= "Req8",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,08,12), new DateTime(2020,08,16).AddDays(1).AddSeconds(-1)), //Sprint 5
                        new Tuple<DateTime, DateTime>(new DateTime(2020,08,18), new DateTime(2020,08,19).AddDays(1).AddSeconds(-1)),
                        new Tuple<DateTime, DateTime>(new DateTime(2020,08,21), new DateTime(2020,08,23).AddDays(1).AddSeconds(-1)),
                        new Tuple<DateTime, DateTime>(new DateTime(2020,11,19), new DateTime(2020,11,24).AddDays(1).AddSeconds(-1)) //Sprint 9
                    }
                },
                new Requirement{
                    Identifier= "Req9",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,09,02), new DateTime(2020,09,09).AddDays(1).AddSeconds(-1)) //Sprint 6
                    }
                },
                new Requirement{
                    Identifier= "Req10",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,07,08), new DateTime(2020,07,19).AddDays(1).AddSeconds(-1)), //Sprint 3
                        new Tuple<DateTime, DateTime>(new DateTime(2020,08,25), new DateTime(2020,08,30).AddDays(1).AddSeconds(-1)), //Sprint 5
                    }
                },
                new Requirement{
                    Identifier= "Req11",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,09,22), new DateTime(2020,10,05).AddDays(1).AddSeconds(-1)), //Sprint 7
                        new Tuple<DateTime, DateTime>(new DateTime(2020,09,14), new DateTime(2020,09,17).AddDays(1).AddSeconds(-1)), //Sprint 6
                        new Tuple<DateTime, DateTime>(new DateTime(2020,09,19), new DateTime(2020,09,21).AddDays(1).AddSeconds(-1)),
                    }
                },
                new Requirement{
                    Identifier= "Req12",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,10,02), new DateTime(2020,10,11).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier= "Req13",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,12,16), new DateTime(2020,12,22).AddDays(1).AddSeconds(-1)),//Sprint 11. 
                        new Tuple<DateTime, DateTime>(new DateTime(2020,12,24), new DateTime(2020,12,27).AddDays(1).AddSeconds(-1)),
                        new Tuple<DateTime, DateTime>(new DateTime(2020,12,30), new DateTime(2021,01,03).AddDays(1).AddSeconds(-1)),
                        new Tuple<DateTime, DateTime>(new DateTime(2021,01,05), new DateTime(2021,01,05).AddDays(1).AddSeconds(-1)),
                        new Tuple<DateTime, DateTime>(new DateTime(2021,01,27), new DateTime(2021,02,03).AddDays(1).AddSeconds(-1)),//Sprint 13.                         
                        new Tuple<DateTime, DateTime>(new DateTime(2021,02,05), new DateTime(2021,02,08).AddDays(1).AddSeconds(-1)),//Sprint 13.                         
                        new Tuple<DateTime, DateTime>(new DateTime(2021,02,10), new DateTime(2021,02,11).AddDays(1).AddSeconds(-1)),//Sprint 13.                         
                        new Tuple<DateTime, DateTime>(new DateTime(2021,02,18), new DateTime(2021,02,24).AddDays(1).AddSeconds(-1)),//Sprint 14.                         

                    }
                },
                new Requirement{
                    Identifier= "Req15",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,10,09), new DateTime(2020,10,12).AddDays(1).AddSeconds(-1)),//Sprint 7.
                        new Tuple<DateTime, DateTime>(new DateTime(2020,10,14), new DateTime(2020,11,06).AddDays(1).AddSeconds(-1))//Sprint 8.
                    }
                },
                new Requirement{
                    Identifier= "Req16",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,10,14), new DateTime(2020,10,23).AddDays(1).AddSeconds(-1)),//Sprint 8.                        
                    }
                },
                new Requirement{
                    Identifier= "Req20",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2021,01,05), new DateTime(2021,01,11)),//Sprint 12. 
                        new Tuple<DateTime, DateTime>(new DateTime(2021,01,13), new DateTime(2021,01,18))
                    }
                }
            };
            string UserName = "BernardinoChin";
            string Password = "4a071e8af62a47d0f01c06a2c129bb69f98f1df6";


            Console.WriteLine("Recuperando información del Repositorio " + Repository + "...");
            IRetrieverStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            CountResponse Lines = Context.CountLines(new CountRequest()
            {
                OrganizationIdentifier = Organization,
                RepositoryIdentifier = Repository,
                Branches = Branches,
                Requirements = Requeriments
            });


            Printer.PrintResult(Repository, Requeriments, Lines.CountResponseItems);
        }
        public static void El20MX_CountLines_FilterByDatesPSI()
        {
            Console.WriteLine("Iniciando Proceso...");

            string Organization = "BernardinoChin";
            string Repository = "El20MX_RepositorioLOC";
            List<string> Branches = new List<string> { "master", "develop", "ft_req19" };
            List<Requirement> Requeriments = new List<Requirement> {
                new Requirement{
                    Identifier= "Req1",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,05,29), new DateTime(2020, 07, 22).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier= "Req4",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,06,03), new DateTime(2020,09,22).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier= "Req5",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,07,22), new DateTime(2020,09,22).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier= "Req6",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,05,27), new DateTime(2020,07,22).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier= "Req7",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,06,26), new DateTime(2020,09,18).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier= "Req8",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,08,12), new DateTime(2020,10,02).AddDays(1).AddSeconds(-1)),
                        new Tuple<DateTime, DateTime>(new DateTime(2020,11,25), new DateTime(2020,11,26).AddDays(1).AddSeconds(-1)),
                        new Tuple<DateTime, DateTime>(new DateTime(2021,01,04), new DateTime(2020,01,04).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier= "Req9",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,09,02), new DateTime(2020,10,21).AddDays(1).AddSeconds(-1)),
                        new Tuple<DateTime, DateTime>(new DateTime(2020,10,23), new DateTime(2020,12,04).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier= "Req10",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,07,08), new DateTime(2020,09,17).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier= "Req11",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,09,22), new DateTime(2020,12,04).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier= "Req12",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,10,02), new DateTime(2020,12,04).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier= "Req13",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,12,16), new DateTime(2021,01,06).AddDays(1).AddSeconds(-1)),
                        new Tuple<DateTime, DateTime>(new DateTime(2021,01,11), new DateTime(2021,01,11).AddDays(1).AddSeconds(-1)),
                        new Tuple<DateTime, DateTime>(new DateTime(2021,02,15), new DateTime(2021,02,15).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier= "Req15",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,10,09), new DateTime(2021,01,04).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier= "Req20",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2021,01,05), new DateTime(2021,01,27)),//Sprint 12. 
                        new Tuple<DateTime, DateTime>(new DateTime(2021,02,08), new DateTime(2021,02,12))
                    }
                },
            };
            string UserName = "BernardinoChin";
            string Password = "6bb1c420f57704b2594fc08528227ab390ae089e";


            Console.WriteLine("Recuperando información del Repositorio " + Repository + "...");
            IRetrieverStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            CountResponse Lines = Context.CountLines(new CountRequest()
            {
                OrganizationIdentifier = Organization,
                RepositoryIdentifier = Repository,
                Branches = Branches,
                Requirements = Requeriments
            });


            Printer.PrintResult(Repository, Requeriments, Lines.CountResponseItems);
        }

        public static void AltaBackOffice_CountLines()
        {
            Console.WriteLine("Iniciando Proceso...");

            string Organization = "bernardinoChin2105";
            string Repository = "Backoffice-Alta-Contribuyente";
            List<string> Branches = new List<string> { "master", "develop" };
            List<Requirement> Requeriments = new List<Requirement> {
                new Requirement{
                        Identifier="Req2"
                },
                new Requirement{
                    Identifier="Req3"
                },
                new Requirement{
                    Identifier="Req4"
                },
                new Requirement{
                    Identifier="Req5"
                },
                new Requirement{
                    Identifier="Req6"
                },
                new Requirement{
                    Identifier="Req7"
                },
                new Requirement{
                    Identifier="Req8"
                },
                new Requirement{
                    Identifier="Req10"
                },
                new Requirement{
                    Identifier="Req11"
                },
                new Requirement{
                    Identifier="Req12"
                }
            };
            string UserName = "bernardinoChin2105";
            string Password = "274a4992cf66627266d6e3a16197ad4724010605";


            Console.WriteLine("Recuperando información del Repositorio " + Repository + "...");
            GithubStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            CountResponse Lines = Context.CountLines(new CountRequest()
            {
                OrganizationIdentifier = Organization,
                RepositoryIdentifier = Repository,
                Branches = Branches,
                Requirements = Requeriments
            });


            Printer.PrintResult(Repository, Requeriments, Lines.CountResponseItems);
        }
        public static void AltaBackOffice_CountLines_FilterByDates()
        {
            Console.WriteLine("Iniciando Proceso...");

            string Organization = "BernardinoChin";
            string Repository = "AltaBackOffice_RepositorioLOC";
            List<string> Branches = new List<string> { "master", "develop" };
            List<Requirement> Requeriments = new List<Requirement> {
                new Requirement{
                     Identifier="Req2",
                     DateRange = new List<Tuple<DateTime, DateTime>>{
                         new Tuple<DateTime, DateTime>(new DateTime(2020,09,28), new DateTime(2020, 09, 29).AddDays(1).AddSeconds(-1)), //Sprint 1
                         new Tuple<DateTime, DateTime>(new DateTime(2020,10,01), new DateTime(2020, 10, 01).AddDays(1).AddSeconds(-1)),
                         new Tuple<DateTime, DateTime>(new DateTime(2020,10,03), new DateTime(2020, 10, 07).AddDays(1).AddSeconds(-1))
                     }
                 },
                 new Requirement{
                     Identifier="Req3",
                     DateRange = new List<Tuple<DateTime, DateTime>>{
                         new Tuple<DateTime, DateTime>(new DateTime(2020,10,09), new DateTime(2020, 10, 20).AddDays(1).AddSeconds(-1)), //Sprint 2
                         new Tuple<DateTime, DateTime>(new DateTime(2020,10,22), new DateTime(2020, 10, 22).AddDays(1).AddSeconds(-1))
                     }
                 },
                 new Requirement{
                     Identifier="Req5",
                     DateRange = new List<Tuple<DateTime, DateTime>>{
                         new Tuple<DateTime, DateTime>(new DateTime(2020,10,26), new DateTime(2020, 10, 28).AddDays(1).AddSeconds(-1)), //Sprint 3
                         new Tuple<DateTime, DateTime>(new DateTime(2020,11,03), new DateTime(2020, 11, 03).AddDays(1).AddSeconds(-1))
                     }
                 },
                 new Requirement{
                     Identifier="Req7",
                     DateRange = new List<Tuple<DateTime, DateTime>>{
                         new Tuple<DateTime, DateTime>(new DateTime(2020,10,21), new DateTime(2020, 10, 26).AddDays(1).AddSeconds(-1)), //Sprint 2                        
                     }
                 }
            };
            string UserName = "BernardinoChin";
            string Password = "4a071e8af62a47d0f01c06a2c129bb69f98f1df6";


            Console.WriteLine("Recuperando información del Repositorio " + Repository + "...");
            IRetrieverStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            CountResponse Lines = Context.CountLines(new CountRequest()
            {
                OrganizationIdentifier = Organization,
                RepositoryIdentifier = Repository,
                Branches = Branches,
                Requirements = Requeriments
            });


            Printer.PrintResult(Repository, Requeriments, Lines.CountResponseItems);
        }
        public static void AltaBackOffice_CountLines_FilterByDatesPSI()
        {
            Console.WriteLine("Iniciando Proceso...");

            string Organization = "BernardinoChin";
            string Repository = "AltaBackOffice_RepositorioLOC";
            List<string> Branches = new List<string> { "master", "develop" };
            List<Requirement> Requeriments = new List<Requirement> {
                new Requirement{
                        Identifier="Req2",
                        DateRange = new List<Tuple<DateTime, DateTime>>{
                            new Tuple<DateTime, DateTime>(new DateTime(2020,09,28), new DateTime(2020, 10, 23).AddDays(1).AddSeconds(-1))
                        }
                },
                new Requirement{
                    Identifier="Req3",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,10,09), new DateTime(2020, 11, 13).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier="Req4",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,10,08), new DateTime(2020, 11, 04).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier="Req7",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,10,09), new DateTime(2020, 11, 11).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier="Req8",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,10,09), new DateTime(2020, 11, 09).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier="Req10",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,10,23), new DateTime(2020, 11, 17).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier="Req11",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,10,09), new DateTime(2020, 10, 19).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier="Req12",
                    DateRange = new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,10,05), new DateTime(2020, 10, 19).AddDays(1).AddSeconds(-1))
                    }
                }
            };
            string UserName = "BernardinoChin";
            string Password = "6bb1c420f57704b2594fc08528227ab390ae089e";


            Console.WriteLine("Recuperando información del Repositorio " + Repository + "...");
            IRetrieverStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            CountResponse Lines = Context.CountLines(new CountRequest()
            {
                OrganizationIdentifier = Organization,
                RepositoryIdentifier = Repository,
                Branches = Branches,
                Requirements = Requeriments
            });


            Printer.PrintResult(Repository, Requeriments, Lines.CountResponseItems);
        }

        public static void Lakeway_CountLines()
        {
            Console.WriteLine("Iniciando Proceso...");

            string Organization = "bernardinoChin2105";
            string Repository = "Lakeway";
            List<string> Branches = new List<string> {
                    "develop",
                    "feature/container-pack",
                    "feature/update-manifest",
                    "feature/rooms_default"
                };
            List<Requirement> Requeriments = new List<Requirement> {
                new Requirement{
                    Identifier="Req2"
                },
                new Requirement{
                    Identifier="Req3"
                },
                new Requirement{
                    Identifier="Req4"
                },
                new Requirement{
                    Identifier="Req5"
                },
                new Requirement{
                    Identifier="Req6"
                },
                new Requirement{
                    Identifier="Req7"
                },
                new Requirement{
                    Identifier="Req8"
                },
                new Requirement{
                    Identifier="Req10"
                },
                new Requirement{
                    Identifier="Req11"
                },
                new Requirement{
                    Identifier="Req12"
                },
                new Requirement{
                    Identifier="Req13"
                },
                new Requirement{
                    Identifier="Req14"
                },
                new Requirement{
                    Identifier="Req15"
                },
                new Requirement{
                    Identifier="Req16"
                },
                new Requirement{
                    Identifier="Req17"
                },
                new Requirement{
                    Identifier="Req18"
                },
                new Requirement{
                    Identifier="Req19"
                },
                new Requirement{
                    Identifier="Req20"
                },
                new Requirement{
                    Identifier="Req21"
                }
            };

            string UserName = "bernardinoChin2105";
            string Password = "274a4992cf66627266d6e3a16197ad4724010605";


            Console.WriteLine("Recuperando información del Repositorio " + Repository + "...");
            GithubStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            CountResponse Lines = Context.CountLines(new CountRequest()
            {
                OrganizationIdentifier = Organization,
                RepositoryIdentifier = Repository,
                Branches = Branches,
                Requirements = Requeriments
            });


            Printer.PrintResult(Repository, Requeriments, Lines.CountResponseItems);
        }
        public static void Lakeway_CountLines_FilterByDates()
        {
            //"feature/update-manifest", No se encontró la rama. 
            Console.WriteLine("Iniciando Proceso...");
            string Organization = "BernardinoChin";
            string Repository = "Lakeway_RepositorioLOC";
            List<string> Branches = new List<string> {
                    "develop",
                    "feature/container-pack",
                    "feature/rooms_default"
                };
            List<Requirement> Requeriments = new List<Requirement> {
                new Requirement{
                    Identifier="Req5",
                    DateRange= new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,11,23),new DateTime(2020,11,26).AddDays(1).AddSeconds(-1)) // Sprint 1
                    }
                },
                new Requirement{
                    Identifier="Req7",
                    DateRange= new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,11,25),new DateTime(2020,11,25).AddDays(1).AddSeconds(-1)), //Sprint 1
                        new Tuple<DateTime, DateTime>(new DateTime(2021,02,05),new DateTime(2021,02,16).AddDays(1).AddSeconds(-1)) //Sprint 4
                    }
                },
                new Requirement{
                    Identifier="Req18",
                    DateRange= new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,12,21),new DateTime(2020,12,22).AddDays(1).AddSeconds(-1)) //Sprint 2
                    }
                },
                new Requirement{
                    Identifier="Req19",
                    DateRange= new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,12,21),new DateTime(2021,02,17).AddDays(1).AddSeconds(-1)) //Backlog
                    }
                },
                new Requirement{
                    Identifier="Req21",
                    DateRange= new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,12,23),new DateTime(2020,12,23).AddDays(1).AddSeconds(-1)), //Sprint 2
                        new Tuple<DateTime, DateTime>(new DateTime(2021,02,06),new DateTime(2021,02,11).AddDays(1).AddSeconds(-1)) //Sprint 4
                    }
                }
            };
            string UserName = "BernardinoChin";
            string Password = "4a071e8af62a47d0f01c06a2c129bb69f98f1df6";
            Console.WriteLine("Recuperando información del Repositorio " + Repository + "...");
            GithubStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            CountResponse Lines = Context.CountLines(new CountRequest()
            {
                OrganizationIdentifier = Organization,
                RepositoryIdentifier = Repository,
                Branches = Branches,
                Requirements = Requeriments
            });


            Printer.PrintResult(Repository, Requeriments, Lines.CountResponseItems);
        }
        public static void Lakeway_CountLines_FilterByDatesPSI()
        {
            //"feature/update-manifest", No se encontró la rama. 
            Console.WriteLine("Iniciando Proceso...");
            string Organization = "BernardinoChin";
            string Repository = "Lakeway_RepositorioLOC";
            List<string> Branches = new List<string> {
                    "develop",
                    "feature/container-pack",
                    "feature/rooms_default"
                };
            List<Requirement> Requeriments = new List<Requirement> {
                new Requirement{
                    Identifier="Req5",
                    DateRange= new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,11,23),new DateTime(2021,01,19).AddDays(1).AddSeconds(-1)) // Sprint 1
                    }
                },
                new Requirement{
                    Identifier="Req7",
                    DateRange= new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,11,25),new DateTime(2020,12,04).AddDays(1).AddSeconds(-1)), //Sprint 1
                        new Tuple<DateTime, DateTime>(new DateTime(2021,02,05),new DateTime(2021,03,01).AddDays(1).AddSeconds(-1)) //Sprint 4
                    }
                },
                new Requirement{
                    Identifier="Req10",
                    DateRange= new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,12,21),new DateTime(2021,01,19).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier="Req12",
                    DateRange= new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,12,21),new DateTime(2021,03,10).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier="Req13",
                    DateRange= new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,12,21),new DateTime(2021,01,19).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier="Req14",
                    DateRange= new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,12,21),new DateTime(2021,01,19).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier="Req15",
                    DateRange= new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,12,21),new DateTime(2021,03,31).AddDays(1).AddSeconds(-1)) //Sprint 2
                    }
                },
                new Requirement{
                    Identifier="Req18",
                    DateRange= new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,12,21),new DateTime(2021,03,31).AddDays(1).AddSeconds(-1)) //Sprint 2
                    }
                },
                new Requirement{
                    Identifier="Req19",
                    DateRange= new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,12,21),new DateTime(2021,01,27).AddDays(1).AddSeconds(-1)),
                        new Tuple<DateTime, DateTime>(new DateTime(2021,02,05),new DateTime(2021,03,01).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier="Req21",
                    DateRange= new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2020,12,23),new DateTime(2021,01,19).AddDays(1).AddSeconds(-1))
                    }
                },
                new Requirement{
                    Identifier="CC1",
                    DateRange= new List<Tuple<DateTime, DateTime>>{
                        new Tuple<DateTime, DateTime>(new DateTime(2021,05,20),new DateTime(2021,05,20).AddDays(1).AddSeconds(-1))
                    }
                }
            };
            string UserName = "BernardinoChin";
            string Password = "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";

            Console.WriteLine("Recuperando información del Repositorio " + Repository + "...");
            GithubStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            CountResponse Lines = Context.CountLines(new CountRequest()
            {
                OrganizationIdentifier = Organization,
                RepositoryIdentifier = Repository,
                Branches = Branches,
                Requirements = new List<Requirement> { },
                Phases = new List<string> { "SC" },
                BetweenStartDate = new DateTime(2021, 05, 20),
                BetweenEndDate = new DateTime(2021, 05, 20).AddDays(1).AddSeconds(-1)
            });


            Printer.PrintResult(Repository, Requeriments, Lines.CountResponseItems);
        }

        public static void HdaSonPDF5_CountLines()
        {
            Console.WriteLine("Iniciando Proceso...");

            string Organization = "ensitech";
            string Repository = "SecHdaSon";
            List<string> Branches = new List<string> {
                    "ft-reingenieria-nominaV1",
                    "calidad",
                    "master",
                    "dev",
                    "produccion"
                };

            List<Requirement> Requeriments = new List<Requirement> {
                new Requirement{
                    Identifier= "cc8"
                },
                new Requirement{
                    Identifier= "cc9"
                },
                new Requirement{
                    Identifier= "cc12"
                },
                new Requirement{
                    Identifier= "cc13"
                },
                new Requirement{
                    Identifier= "cc16"
                },
                new Requirement{
                    Identifier= "cc17"
                },
                new Requirement{
                    Identifier= "cc1"
                },
                new Requirement{
                    Identifier= "cc2"
                },
                new Requirement{
                    Identifier= "Req2"
                }
            };
            string UserName = "BernardinoChin";
            string Password = "4a071e8af62a47d0f01c06a2c129bb69f98f1df6";


            Console.WriteLine("Recuperando información del Repositorio " + Repository + "...");
            GithubStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            CountResponse Lines = Context.CountLines(new CountRequest()
            {
                OrganizationIdentifier = Organization,
                RepositoryIdentifier = Repository,
                Branches = Branches,
                Requirements = Requeriments
            });


            Printer.PrintResult(Repository, Requeriments, Lines.CountResponseItems);
        }
    }
}
