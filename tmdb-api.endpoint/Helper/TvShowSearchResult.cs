using Newtonsoft.Json;
using System.Collections.Generic;

namespace tmdb_api.endpoint.Helper
{
    public class TvShowSearchResult
    {
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("results")]
        public List<TvShowModel> Results { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
    }
}
