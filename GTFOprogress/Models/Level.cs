using System;
using GTFOProgress.Common.Tier;
using GTFOProgress.Common.TaskState;

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
        public TaskState secondaryState { get; set; }
        public TaskState overloadState { get; set; }
        public TaskState prisonerEfficiency { get; set; }


        public Level(string name, string title, Tier tier, int level, bool secondary, bool overload)
        {
            this.name = name;
            this.title = title;
            this.tier = tier;
            this.level = level;
            this.secondary = secondary;
            this.overload = overload;
            this.secondaryState = (this.hasSecondary()) ? TaskState.Incomplete : TaskState.Empty;
            this.overloadState = (this.hasOverload()) ? TaskState.Incomplete : TaskState.Empty;
            this.prisonerEfficiency = (this.hasPrisonerEfficiency()) ? TaskState.Incomplete : TaskState.Empty;
        }

        public bool hasSecondary()
        {
            return secondary;
        }

        public bool hasOverload() 
        { 
            return overload; 
        }

        public bool hasPrisonerEfficiency()
        {
            return (secondary && overload);
        }
    }
}



