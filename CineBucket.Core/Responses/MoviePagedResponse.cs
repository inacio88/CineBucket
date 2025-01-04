using System.Text.Json.Serialization;

namespace CineBucket.Core.Responses
{
    public class MoviePagedResponse
    {
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }
        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
        [JsonPropertyName("page")]
        public int Page { get; set; }
        [JsonPropertyName("results")]
        public List<MovieResponse> Results { get; set; } = new();
    }
}