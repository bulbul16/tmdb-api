using Newtonsoft.Json;
using System.Collections.Generic;

namespace tmdb_api.endpoint.Helper
{
    public class MovieSearchResult
    {
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("results")]
        public List<MovieModel> Results { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
    }
}
