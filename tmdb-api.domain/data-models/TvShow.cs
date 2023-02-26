using System;
using System.Collections.Generic;
using System.Text;

namespace tmdb_api.domain.data_models
{
    public class TvShow
    {
        public int Id { get; set; }
        public int TvShowId { get; set; }
        public int SearchId { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string OriginalLanguage { get; set; }
        public bool Adult { get; set; }
        public string BackdropPath { get; set; }
        public string FirstAirDate { get; set; }
        public string Overview { get; set; }
        public decimal Popularity { get; set; }
        public string PosterPath { get; set; }
        public decimal VoteAverage { get; set; }
        public int VoteCount { get; set; }
    }
}
