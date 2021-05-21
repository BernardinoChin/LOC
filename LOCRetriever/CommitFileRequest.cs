namespace LOCRetriever
{
    public class CommitFileRequest
    {
        public string OrganizationIdentifier { get; set; }
        public string RepositoryIdentifier { get; set; }
        public string CommitIdentifier { get; set; }
    }
}
