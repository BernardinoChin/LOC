using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOCRetriever
{
    public class CommitFile
    {
        public string FileId { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }        

        public int AddedLines { get; set; }

        public int DeletedLines { get; set; }
    }
}
