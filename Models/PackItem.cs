namespace StuffPack.Models
{
    public class PackItem
    {
        public long Id { get; set; }
        
        public string Description { get; set; }

        public decimal Weight { get; set; }

        public decimal Volume { get; set; }

        public string Assignee { get; set; }
    }
}