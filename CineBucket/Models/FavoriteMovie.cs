namespace CineBucket.Models
{
    public class FavoriteMovie
    {
        public int Id { get; set; }
        public int TmdbId { get; set; }
        public string? OriginalTitle { get; set; } = string.Empty;
        public string? PosterPath { get; set; } = string.Empty;
        public DateTime? ReleaseDate { get; set; }
        public int? Runtime { get; set; }
        public string? Status { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int Priority { get; set; }
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;
    }
}