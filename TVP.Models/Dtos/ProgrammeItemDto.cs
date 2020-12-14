using System;

namespace TVP.Models.Dtos
{
    public class ProgrammeItemDto
    {
        public string ChannelName { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public string Title { get; set; }
        public string IslTitle { get; set; }
        public string SubTitle { get; set; }
        public int SeriesNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public int NumberOfEpisodes { get; set; }
        public string Category { get; set; }
        public string PgRating { get; set; }
        public string Description { get; set; }
    }
}