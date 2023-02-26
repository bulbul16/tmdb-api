using Newtonsoft.Json;

namespace tmdb_api.endpoint.Helper
{
    public class MovieModel
    {
        [JsonProperty("Id")]
        public int MovieId { get; set; }
        [JsonProperty("adult")]
        public bool Adult { get; set; }
        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }
        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }
        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }
        [JsonProperty("overview")]
        public string Overview { get; set; }
        [JsonProperty("popularity")]
        public string Popularity { get; set; }
        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }
        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("video")]
        public bool Video { get; set; }
        [JsonProperty("vote_average")]
        public decimal VoteAverage { get; set; }
        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }
    }
}
