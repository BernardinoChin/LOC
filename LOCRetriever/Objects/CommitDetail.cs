using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOCRetriever
{
    public class CommitDetail
    {
        [JsonProperty(PropertyName = "files")]
        public List<CommitFile> Files { get; set; }

        
        public int AddedLines { get; set; }

        
        public int DeletedLines { get; set; }        
    }
}
