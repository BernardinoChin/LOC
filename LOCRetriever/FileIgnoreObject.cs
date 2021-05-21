using System.Collections.Generic;

namespace LOCRetriever
{

    public class FileIgnoreObject
    {
        public ExclusionType FileExclusionType { get; set; }
        public List<string> FileExtensionIgnoreList { get; set; }
        public List<string> FileNameIgnoreList { get; set; }

        public FileIgnoreObject()
        {
            FileExtensionIgnoreList = new List<string>();
            FileNameIgnoreList = new List<string>();
        }
    }
}
