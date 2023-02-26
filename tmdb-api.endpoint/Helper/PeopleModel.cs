using Newtonsoft.Json;

namespace tmdb_api.endpoint.Helper
{
    public class PeopleModel
    {
        [JsonProperty("adult")]
        public bool Adult { get; set; }
        [JsonProperty("gender")]
        public int Gender { get; set; }
        [JsonProperty("id")]
        public int PeopleId { get; set; }
        //[JsonProperty("known_for")]
        //public string KnownFor { get; set; }
        [JsonProperty("known_for_department")]
        public string KnownForDepartment { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("original_name")]
        public string OriginalName { get; set; }
        [JsonProperty("popularity")]
        public decimal Popularity { get; set; }
        [JsonProperty("profile_path")]
        public string ProfilePath { get; set; }
    }
}
