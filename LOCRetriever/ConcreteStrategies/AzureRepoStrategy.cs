using System;
using System.Collections.Generic;

namespace LOCRetriever
{
    public class AzureRepoStrategy : IRetrieverStrategy
    {      
        public List<Branche> GetBranches(string OrganizationIdentifier, string RepositoryIdentifier)
        {
            throw new NotImplementedException();
        }

        public List<CommitFile> GetCommitFiles(CommitFileRequest CommitFileRequest)
        {
            throw new NotImplementedException();
        }

        public List<Commit> GetCommits(CommitRequest CommitRequest)
        {
            throw new NotImplementedException();
        }

        public CountResponse CountLines(CountRequest CountRequest)
        {
            throw new NotImplementedException();
        }
    }
}
