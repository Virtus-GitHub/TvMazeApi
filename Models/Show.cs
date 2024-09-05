namespace TvMazeApi.Models
{
    public class Show
    {
        public int? id { get; set; }
        public string? url { get; set; }
        public string? name { get; set; }
        public string? type { get; set; }
        public string? language { get; set; }
        public List<string>? genres { get; set; }
        public string? status { get; set; }
        public int? runtime { get; set; }
        public int? averageRuntime { get; set; }
        public DateTime? premiered { get; set; }
        public DateTime? ended { get; set; }
        public string? officialSite { get; set; }
        public Schedule? schedule { get; set; }
        public Rating? rating { get; set; }
        public int? weight { get; set; }
        public Network? network { get; set; }
        public WebChannel? webChannel { get; set; }
        public Country? dvdCountry { get; set; }
        public External? externals { get; set; }
        public Image? image { get; set; }
        public string? summary { get; set; }
        public int? updated { get; set; }
        public Link? _links { get; set; }
    }
}
