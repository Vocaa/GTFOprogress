using System;
using GTFOprogress.Common;

namespace GTFOprogress.Models
{
    public class Level
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public Tier Tier { get; set; }
        public int Stage { get; set; }
        public bool Secondary { get; set; }
        public bool Overload { get; set; }

        private TaskState _levelCompletion = TaskState.Incomplete;
        public TaskState LevelCompletion
        {
            get => _levelCompletion;
            set => _levelCompletion = (value == TaskState.Empty) ? TaskState.Incomplete : value;
        }

        private TaskState? _secondaryState;
        public TaskState SecondaryState
        {
            get => _secondaryState ?? (Secondary ? TaskState.Incomplete : TaskState.Empty);
            set => _secondaryState = value;
        }

        private TaskState? _overloadState;
        public TaskState OverloadState
        {
            get => _overloadState ?? (Overload ? TaskState.Incomplete : TaskState.Empty);
            set => _overloadState = value;
        }

        private TaskState? _prisonerEfficiency;
        public TaskState PrisonerEfficiency
        {
            get => _prisonerEfficiency ?? ((Secondary && Overload) ? TaskState.Incomplete : TaskState.Empty);
            set => _prisonerEfficiency = value;
        }

        public bool hasSecondary()
        {
            return Secondary;
        }

        public bool hasOverload() 
        { 
            return Overload; 
        }

        public bool hasPrisonerEfficiency()
        {
            return (Secondary && Overload);
        }
    }
}



