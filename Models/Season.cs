namespace TvMazeApi.Models
{
    public class Season
    {
        public int? id { get; set; }
        public string? url { get; set; }
        public int? number { get; set; }
        public string? name { get; set; }
        public int? episodeOrder { get; set; }
        public DateTime? premiereDate { get; set; }
        public DateTime? endDate { get; set; }
        public Network? network { get; set; }
        public WebChannel webChannel { get; set; }
        public Image? image { get; set; }
        public string? summary  { get; set; }
        public LinkSelf? _links { get; set; }
    }
}
