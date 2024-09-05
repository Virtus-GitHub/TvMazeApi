namespace TvMazeApi.Models
{
    public class Person
    {
        public int? id { get; set; }
        public string? url { get; set; }
        public string? name { get; set; }
        public Country? country { get; set; }
        public DateTime? birthday { get; set; }
        public DateTime? deathday { get; set; }
        public string? gender { get; set; }
        public Image? image { get; set; }
        public string? updated { get; set; }
        public LinkSelf? _links { get; set; }
    }
}
