using System.Collections.Generic;

namespace LOCRetriever
{
    public class RetrieverContext
    {
        private readonly IRetrieverStrategy CurrentStrategy;

        public RetrieverContext(IRetrieverStrategy _CurrentStrategy)
        {
            this.CurrentStrategy = _CurrentStrategy;
        }


        public List<Branche> GetBranches(string OrganizationIdentifier, string RepositoryIdentifier)
        {
            return this.CurrentStrategy.GetBranches(OrganizationIdentifier, RepositoryIdentifier);
        }


        public List<Commit> GetCommits(CommitRequest _CommitRequest)
        {
            return this.CurrentStrategy.GetCommits(_CommitRequest);
        }


        public List<CommitFile> GetCommitFiles(CommitFileRequest _CommitFileRequest)
        {
            return this.CurrentStrategy.GetCommitFiles(_CommitFileRequest);
        }


        public CountResponse CountLines(CountRequest _CountRequest)
        {
            return this.CurrentStrategy.CountLines(_CountRequest);
        }
    }
}
