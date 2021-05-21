using System.Collections.Generic;

namespace LOCRetriever
{
    public interface IRetrieverStrategy
    {
        List<Branche> GetBranches(string OrganizationIdentifier, string RepositoryIdentifier);
        List<Commit> GetCommits(CommitRequest CommitRequest);
        List<CommitFile> GetCommitFiles(CommitFileRequest CommitFileRequest);
        CountResponse CountLines(CountRequest CountRequest);
    }
}
