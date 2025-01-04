using System.Text.Json.Serialization;


namespace CineBucket.Core.Responses
{
public class PagedResponse<TData> : Response<TData>
    {
        [JsonConstructor]
        public PagedResponse(TData data, int totalCount, int page, int totalPage) : base(data)
        {
            Results = data;
            TotalResults = totalCount;
            Page = page;
            TotalPages = totalPage;
        }


        public PagedResponse(TData? data, int code =200, string? message = null):base(data, code, message)
        {}

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }
        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
        [JsonPropertyName("page")]
        public int Page { get; set; }

    }
}