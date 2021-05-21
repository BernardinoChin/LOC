using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOCRetriever
{
    public class Commit
    {
        public string CommitId { get; set; }

        public string Message { get; set; }

        public string Author { get; set; }

        public DateTime CreatedDate { get; set; }

        public int AddedLines { get; set; }

        public int DeletedLines { get; set; }

        public List<CommitFile> Files { get; set; }
    }
}
