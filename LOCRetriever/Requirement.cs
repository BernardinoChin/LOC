using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LOCRetriever
{
    public class Requirement
    {
        public string Identifier { get; set; }
        public List<Tuple<DateTime, DateTime>> DateRange { get; set; }

        public Requirement()
        {
            DateRange = new List<Tuple<DateTime, DateTime>>();
        }
    }
}
