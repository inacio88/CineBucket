namespace CineBucket.Models
{
    public class Movie
    {
        public bool Adult { get; set; }
        public string BackdropPath { get; set; } = string.Empty;
        public int Id { get; set; }
        public string ImdbId { get; set; } = string.Empty;
        public string Homepage { get; set; } = string.Empty;
        public string OriginalLanguage { get; set; } = string.Empty;
        public string OriginalTitle { get; set; } = string.Empty;
        public string Overview { get; set; } = string.Empty;
        public double Popularity { get; set; }
        public string PosterPath { get; set; } = string.Empty;
        public string ReleaseDate { get; set; } = string.Empty;
        public decimal Budget { get; set; }
        public decimal Revenue { get; set; }
        public int Runtime { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Tagline { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public bool Video { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
    }
}