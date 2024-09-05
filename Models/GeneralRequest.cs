namespace TvMazeApi.Models
{
    public class GeneralRequest
    {
        public int showId { get; set; }
        public int? episodeId { get; set; }
        public int? seasonId { get; set; }
        public DateTime? episodeDate { get; set; }

    }
}
