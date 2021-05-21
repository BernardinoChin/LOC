using System;

namespace LOCRetriever
{
    public class CommitRequest
    {
        public string OrganizationIdentifier { get; set; }
        public string RepositoryIdentifier { get; set; }
        public string BrancheIdentifier { get; set; }
        public DateTime Since { get; set; }
        public DateTime Until { get; set; }
    }
}
