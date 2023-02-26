using Newtonsoft.Json;

namespace tmdb_api.endpoint.Helper
{
    public class TvShowModel
    {
        [JsonProperty("adult")]
        public bool Adult { get; set; }
        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }
        [JsonProperty("first_air_date")]
        public string FirstAirDate { get; set; }
        [JsonProperty("id")]
        public int TvShowId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }
        [JsonProperty("original_name")]
        public string OriginalName { get; set; }
        [JsonProperty("overview")]
        public string Overview { get; set; }
        [JsonProperty("popularity")]
        public decimal Popularity { get; set; }
        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }
        [JsonProperty("vote_average")]
        public decimal VoteAverage { get; set; }
        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }
    }
}
