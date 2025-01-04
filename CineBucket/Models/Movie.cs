namespace CineBucket.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string OriginalTitle { get; set; } = string.Empty;
        public string PosterPath { get; set; } = string.Empty;
        public string ReleaseDate { get; set; } = string.Empty;
        public int Runtime { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int Priority { get; set; }
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;
    }
}