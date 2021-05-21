using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LOCRetriever;
using System.Linq;

namespace LOCTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BernardinoChin2105RepositorioLOC_RetrieveBranches_Get3Branches()
        {
            /*  
             *  Given: 
             *      Organización    :   BernardinoChin2105.
             *      Repositorio     :   RepositorioLOC.             
             *  When:
             *      Intento recuperar las ramas
             *  Then: 
             *      Se deben obtener 3 ramas.
             *      Se deben tener: master, rama1, rama2.
            */

            string Organization = "bernardinoChin2105";
            string Repository = "RepositorioLOC";
            string UserName = "bernardinoChin2105";
            string Password = "274a4992cf66627266d6e3a16197ad4724010605";

            GithubStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            List<Branche> lsBranches = Context.GetBranches(Organization, Repository);


            Assert.IsTrue(lsBranches.Count == 3);
            Assert.IsTrue(lsBranches.Where(x => x.Name == "master").Count() == 1);
            Assert.IsTrue(lsBranches.Where(x => x.Name == "rama1").Count() == 1);
            Assert.IsTrue(lsBranches.Where(x => x.Name == "rama2").Count() == 1);
        }


        [TestMethod]
        public void BernardinoChin2105RepositorioLOCMaster_RetrieveCommits_Get12Commits()
        {
            /*  
             *  Given: 
             *      Organización    :   bernardinoChin2105.
             *      Repositorio     :   RepositorioLOC.           
             *      Branche         :   master
             *  When:
             *      Intento recuperar los commits.
             *  Then: 
             *      Se deben obtener 12 commits.             
            */

            string Organization = "bernardinoChin2105";
            string Repository = "RepositorioLOC";
            string Branche = "master";
            string UserName = "BernardinoChin2105";
            string Password = "274a4992cf66627266d6e3a16197ad4724010605";

            GithubStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            List<Commit> lsCommits = Context.GetCommits(new CommitRequest()
            {
                OrganizationIdentifier = Organization,
                RepositoryIdentifier = Repository,
                BrancheIdentifier = Branche,
                Since = new DateTime()
            });


            Assert.IsTrue(lsCommits.Count == 12);
        }


        [TestMethod]
        public void BernardinoChin2105RepositorioLOCMaster_RetrieveCommitsSince13Feb2021_Get4Commits()
        {
            /*  
             *  Given: 
             *      Organización    :   bernardinoChin2105.
             *      Repositorio     :   RepositorioLOC.
             *      Branche         :   master
             *  When:
             *      Intento recuperar los commits a partir del 13 de Feb del 2021.
             *  Then: 
             *      Se deben obtener 12 commits.
            */

            string Organization = "bernardinoChin2105";
            string Repository = "RepositorioLOC";
            string Branche = "master";
            string UserName = "BernardinoChin2105";
            string Password = "274a4992cf66627266d6e3a16197ad4724010605";

            GithubStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            List<Commit> lsCommits = Context.GetCommits(new CommitRequest()
            {
                OrganizationIdentifier = Organization,
                RepositoryIdentifier = Repository,
                BrancheIdentifier = Branche,
                Since = new DateTime(2021, 02, 13)
            });


            Assert.IsTrue(lsCommits.Count == 4);
        }


        [TestMethod]
        public void BernardinoChin2105RepositorioLOCGivenACommit_RetrieveFiles_Get2Files()
        {
            /*  
             *  Given: 
             *      Organización    :   bernardinoChin2105.
             *      Repositorio     :   RepositorioLOC.
             *      Branche         :   any
             *      Commit          :   61269547bca339125451ff2ce7b327367144a5f5
             *  When:
             *      Intento recuperar los commits a partir del 13 de Feb del 2021.
             *  Then: 
             *      Se deben obtener 12 commits.
            */

            string Organization = "bernardinoChin2105";
            string Repository = "RepositorioLOC";
            string Commit = "a74a96da0d08f97c6f84513eec9d2c99eb14495e";
            string UserName = "BernardinoChin2105";
            string Password = "274a4992cf66627266d6e3a16197ad4724010605";

            GithubStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            List<CommitFile> lsFiles = Context.GetCommitFiles(new CommitFileRequest()
            {
                OrganizationIdentifier = Organization,
                RepositoryIdentifier = Repository,
                CommitIdentifier = Commit
            });


            Assert.IsTrue(lsFiles.Count == 1);
            Assert.IsTrue(lsFiles.FirstOrDefault().AddedLines == 1);
            Assert.IsTrue(lsFiles.FirstOrDefault().DeletedLines == 0);
        }


        [TestMethod]
        public void BernardinoChin2105RepositorioLOCMaster_CountLines_Get26LOC()
        {
            /*  
            *  Given: 
            *      Organización    :   bernardinoChin2105.
            *      Repositorio     :   RepositorioLOC.
            *      Branche         :   master            
            *  When:
            *      Intento contar las líneas de la rama
            *  Then: 
            *      Se deben obtener 26 líneas agregadas y 6 líneas eliminadas. 
           */

            string Organization = "bernardinoChin2105";
            string Repository = "RepositorioLOC";
            List<string> Branches = new List<string> { "master" };
            List<Requirement> Requeriments = new List<Requirement>();
            string UserName = "BernardinoChin2105";
            string Password = "274a4992cf66627266d6e3a16197ad4724010605";


            GithubStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            CountResponse Lines = Context.CountLines(new CountRequest()
            {
                OrganizationIdentifier = Organization,
                RepositoryIdentifier = Repository,
                Branches = Branches,
                Requirements = Requeriments,
                CommitIgnore = new CommitIgnoreObject(),
                FileIgnore = new FileIgnoreObject()
            });


            Assert.IsTrue(Lines.CountResponseItems.Count == 1);
            Assert.IsTrue(Lines.CountResponseItems.FirstOrDefault().Requirement == "Todos");
            Assert.IsTrue(Lines.CountResponseItems.FirstOrDefault().LinesOfCodeAdded == 26);
        }


        [TestMethod]
        public void BernardinoChin2105RepositorioLOCMasterRama2_CountLines_Get27LOC()
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

            string Organization = "bernardinoChin2105";
            string Repository = "RepositorioLOC";
            List<string> Branches = new List<string> { "master", "rama2" };
            List<Requirement> Requeriments = new List<Requirement>();
            string UserName = "BernardinoChin2105";
            string Password = "274a4992cf66627266d6e3a16197ad4724010605";


            GithubStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            CountResponse Lines = Context.CountLines(new CountRequest()
            {
                OrganizationIdentifier = Organization,
                RepositoryIdentifier = Repository,
                Branches = Branches,
                Requirements = Requeriments,
                CommitIgnore = new CommitIgnoreObject(),
                FileIgnore = new FileIgnoreObject()
            });


            Assert.IsTrue(Lines.CountResponseItems.Count == 1);
            Assert.IsTrue(Lines.CountResponseItems.FirstOrDefault().Requirement == "Todos");
            Assert.IsTrue(Lines.CountResponseItems.FirstOrDefault().LinesOfCodeAdded == 27);
        }


        [TestMethod]
        public void BernardinoChin2105RepositorioLOCMasterRama2C1C2_CountLines_Get5LOC()
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

            string Organization = "bernardinoChin2105";
            string Repository = "RepositorioLOC";
            List<string> Branches = new List<string> { "master", "rama2" };
            List<Requirement> Requeriments = new List<Requirement> {
                new Requirement{
                        Identifier= "c1"
                    },
                new Requirement{
                        Identifier= "c2"
                    }
            };
            string UserName = "BernardinoChin2105";
            string Password = "274a4992cf66627266d6e3a16197ad4724010605";


            GithubStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            CountResponse Lines = Context.CountLines(new CountRequest()
            {
                OrganizationIdentifier = Organization,
                RepositoryIdentifier = Repository,
                Branches = Branches,
                Requirements = Requeriments,
                CommitIgnore = new CommitIgnoreObject(),
                FileIgnore = new FileIgnoreObject()
            });


            Assert.IsTrue(Lines.CountResponseItems.Count == 2);
            Assert.IsTrue(Lines.CountResponseItems.Where(x => x.Requirement == "c1").Count() == 1);
            Assert.IsTrue(Lines.CountResponseItems.Where(x => x.Requirement == "c1").FirstOrDefault().LinesOfCodeAdded == 3);
            Assert.IsTrue(Lines.CountResponseItems.Where(x => x.Requirement == "c2").Count() == 1);
            Assert.IsTrue(Lines.CountResponseItems.Where(x => x.Requirement == "c2").FirstOrDefault().LinesOfCodeAdded == 2);
        }


        [TestMethod]
        public void BernardinoChin2105RepositorioLOCMasterRama2_CountLines_Get26LOC()
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

            string Organization = "bernardinoChin2105";
            string Repository = "RepositorioLOC";
            List<string> Branches = new List<string> { "master", "rama2" };
            List<Requirement> Requeriments = new List<Requirement>();
            string UserName = "BernardinoChin2105";
            string Password = "274a4992cf66627266d6e3a16197ad4724010605";


            GithubStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            CountResponse Lines = Context.CountLines(new CountRequest()
            {
                OrganizationIdentifier = Organization,
                RepositoryIdentifier = Repository,
                Branches = Branches,
                Requirements = Requeriments,
                CommitIgnore = new CommitIgnoreObject
                {
                    CommitExclusionType = ExclusionType.ExcludeThese,
                    CommitIgnoreList = new List<string> {
                        "inicial"
                    }
                },
                FileIgnore = new FileIgnoreObject()
            });


            Assert.IsTrue(Lines.CountResponseItems.Count == 1);
            Assert.IsTrue(Lines.CountResponseItems.FirstOrDefault().Requirement == "Todos");
            Assert.IsTrue(Lines.CountResponseItems.FirstOrDefault().LinesOfCodeAdded == 26);
        }


        [TestMethod]
        public void BernardinoChin2105RepositorioLOCMasterRama2_CountLines_Get24LOC()
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

            string Organization = "bernardinoChin2105";
            string Repository = "RepositorioLOC";
            List<string> Branches = new List<string> { "master", "rama2" };
            List<Requirement> Requeriments = new List<Requirement>();
            string UserName = "BernardinoChin2105";
            string Password = "274a4992cf66627266d6e3a16197ad4724010605";


            GithubStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            CountResponse Lines = Context.CountLines(new CountRequest()
            {
                OrganizationIdentifier = Organization,
                RepositoryIdentifier = Repository,
                Branches = Branches,
                Requirements = Requeriments,
                CommitIgnore = new CommitIgnoreObject
                {
                    CommitExclusionType = ExclusionType.ExcludeThese,
                    CommitIgnoreList = new List<string> {
                        "inicial"
                    }
                },
                FileIgnore = new FileIgnoreObject
                {
                    FileExclusionType = ExclusionType.ExcludeThese,
                    FileNameIgnoreList = new List<string> {
                        ".md"
                    }
                }
            });


            Assert.IsTrue(Lines.CountResponseItems.Count == 1);
            Assert.IsTrue(Lines.CountResponseItems.FirstOrDefault().Requirement == "Todos");
            Assert.IsTrue(Lines.CountResponseItems.FirstOrDefault().LinesOfCodeAdded == 24);
        }


        [TestMethod]
        public void EnsitechHdaSon_RetrieveBranches_Get33Branches()
        {
            /*  
             *  Given: 
             *      Organización    :   Ensitech.
             *      Repositorio     :   HdaSon.             
             *  When:
             *      Intento recuperar las ramas
             *  Then: 
             *      Se deben obtener 32 ramas.
             *      Se debe tener una rama nombrada ft-BBVA-Request.
            */

            string Organization = "ensitech";
            string Repository = "SecHdaSon";
            string UserName = "BernardinoChin";
            string Password = "4a071e8af62a47d0f01c06a2c129bb69f98f1df6";

            GithubStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            List<Branche> lsBranches = Context.GetBranches(Organization, Repository);


            Assert.IsTrue(lsBranches.Count == 33);
            Assert.IsTrue(lsBranches.Where(x => x.Name == "ft-BBVA-Request").Count() == 1);
        }


        [TestMethod]
        public void EnsitechHdaSonMaster_RetrieveCommits_Get4123Commits()
        {
            /*  
             *  Given: 
             *      Organización    :   Ensitech.
             *      Repositorio     :   HdaSon.           
             *      Branche         :   master
             *  When:
             *      Intento recuperar los commits.
             *  Then: 
             *      Se deben obtener 4,123 commits.             
            */

            string Organization = "ensitech";
            string Repository = "SecHdaSon";
            string Branche = "master";
            string UserName = "BernardinoChin";
            string Password = "4a071e8af62a47d0f01c06a2c129bb69f98f1df6";

            GithubStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            List<Commit> lsCommits = Context.GetCommits(new CommitRequest()
            {
                OrganizationIdentifier = Organization,
                RepositoryIdentifier = Repository,
                BrancheIdentifier = Branche,
                Since = new DateTime()
            });


            Assert.IsTrue(lsCommits.Count == 4123);
        }


        [TestMethod]
        public void EnsitechHdaSonMaster_RetrieveCommitsSince05Feb2021_Get5Commits()
        {
            /*  
             *  Given: 
             *      Organización    :   Ensitech.
             *      Repositorio     :   HdaSon.           
             *      Branche         :   master
             *  When:
             *      Intento recuperar los commits.
             *  Then: 
             *      Se deben obtener 5 commits.             
            */

            string Organization = "ensitech";
            string Repository = "SecHdaSon";
            string Branche = "master";
            string UserName = "BernardinoChin";
            string Password = "4a071e8af62a47d0f01c06a2c129bb69f98f1df6";

            GithubStrategy GitHubStrat = new GithubStrategy(UserName, Password);
            RetrieverContext Context = new RetrieverContext(GitHubStrat);
            List<Commit> lsCommits = Context.GetCommits(new CommitRequest()
            {
                OrganizationIdentifier = Organization,
                RepositoryIdentifier = Repository,
                BrancheIdentifier = Branche,
                Since = new DateTime(2021, 02, 05)
            });


            Assert.IsTrue(lsCommits.Count == 5);
        }
    }
}
