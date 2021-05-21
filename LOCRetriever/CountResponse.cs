using System;
using System.Collections.Generic;

namespace LOCRetriever
{
    public class CountResponse
    {
        public List<CountResponseItem> CountResponseItems { get; set; }

        public CountResponse()
        {
            this.CountResponseItems = new List<CountResponseItem>();
        }
    }

    public class CountResponseItem
    {
        public string Requirement { get; set; }
        public int LinesOfCodeAdded { get; set; }
        public List<CountResponseCommitItem> Commits { get; set; }

        public CountResponseItem()
        {
            this.Commits = new List<CountResponseCommitItem>();
        }
    }

    public class CountResponseCommitItem
    {
        public string CommitId { get; set; }
        public string Message { get; set; }

        public string CreatedAt { get; set; }
        public CountResponseCommitItem()
        {
            this.CommitId = string.Empty;
            this.CommitId = string.Empty;
            this.CreatedAt = string.Empty;
        }
    }
}
