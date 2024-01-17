namespace GTFOprogress.Models
{
    public class State
    {
        public string? Name { get; set; }
        public string? Version { get; set; }
        public string? LastUpdated { get; set; }

        public List<Rundown>? Data { get; set; }

        public void MergeState(State input)
        {
            foreach (Rundown rundown in input.Data)
            {
                this.Data.Where(i => i.Id == rundown.Id).First().MergeRundown(rundown.Levels);
            }
        }
    }


}
