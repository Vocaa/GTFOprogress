namespace GTFOprogress.Models
{
    public class State
    {
        public string? Name { get; set; }
        public string? Version { get; set; }
        public string? LastUpdated { get; set; }

        public List<Rundown>? Data { get; set; }
    }
}
