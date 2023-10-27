using GTFOProgress.Models.Level;

namespace GTFOprogress.Models
{

    public class Rundown
    {
        public int id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string identifier { get; set; }
        public List<Level> levels { get; set; }

        public Rundown(int id, string name, string title, string identifier, List<Level> levels)
        {
            this.id = id;
            this.name = name;
            this.title = title;
            this.identifier = identifier;
            this.levels = levels ?? new List<Level>(); // Ensure levels is never null
        }

    }
}