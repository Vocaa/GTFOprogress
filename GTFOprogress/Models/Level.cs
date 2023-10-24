using System;
using GTFOProgress.Common.Tier;

namespace GTFOProgress.Models.Level
{
    public class Level
    {
        public string name { get; set; }
        public string title { get; set; }
        public Tier tier { get; set; }
        public int level { get; set; }
        public bool secondary { get; set; }
        public bool overload { get; set; }
    }
}



