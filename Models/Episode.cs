﻿namespace TvMazeApi.Models
{
    public class Episode
    {
        public int? id {  get; set; }
        public string? url { get; set; }
        public string? name { get; set; }
        public int? season { get; set; }
        public int? number { get; set; }
        public string? type { get; set; }
        public DateTime? airdate { get; set; }
        public string? airtime { get; set; }
        public DateTime? airstamp { get; set; }
        public int? runtime { get; set; }
        public Rating? rating { get; set; }
        public Image? image { get; set; }
        public string? summary { get; set; }
        public LinkEpisode? _links { get; set; }
    }
}
