using GTFOprogress.Common;

namespace GTFOprogress.Models
{

    public class Rundown
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Identifier { get; set; }
        public int MainTotal {  get; set; }
        public int SecondaryTotal {  get; set; }
        public int OverloadTotal {  get; set; }
        public int PETotal {  get; set; }

        public List<Level> Levels { get; set; }

        public Rundown(int id, string name, string title, string identifier, List<Level> levels)
        {
            this.Id = id;
            this.Name = name;
            this.Title = title;
            this.Identifier = identifier;
            this.Levels = levels ?? new List<Level>();
        }

        public List<Level> GetTier(Tier tier)
        {
            return this.Levels.Where(level => level.Tier == tier).ToList();
        }

        public int GetCompletedLevelsCount() => Levels.Where(l => l.LevelCompletion == TaskState.Complete).Count();
        public int GetCompletedSecondariesCount() => Levels.Where(l => l.SecondaryState == TaskState.Complete).Count();
        public int GetCompletedOverloadCount() => Levels.Where(l => l.OverloadState == TaskState.Complete).Count();
        public int GetCompletedPECount() => Levels.Where(l=>l.PrisonerEfficiency == TaskState.Complete).Count();
    }
}