using System.Collections.Generic;

namespace LOCRetriever
{
    public class CommitIgnoreObject
    {
        public ExclusionType CommitExclusionType { get; set; }
        public List<string> CommitIgnoreList { get; set; }

        public CommitIgnoreObject()
        {
            CommitIgnoreList = new List<string>();
        }
    }
}
