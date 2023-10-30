using GTFOprogress.Models;

namespace GTFOprogress.Models
{

    public class Rundown
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Identifier { get; set; }
        public List<Level> Levels { get; set; }

        public Rundown(int id, string name, string title, string identifier, List<Level> levels)
        {
            this.Id = id;
            this.Name = name;
            this.Title = title;
            this.Identifier = identifier;
            this.Levels = levels ?? new List<Level>(); // Ensure levels is never null
        }

    }
}