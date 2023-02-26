using System;
using System.Collections.Generic;
using System.Text;

namespace tmdb_api.domain.data_models
{
    public class Movie
    {
        public int Id { get; set; }
        public int SearchId { get; set; }
        public int MovieId { get; set; }
        public bool Adult { get; set; }
        public string BackdropPath { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public string Popularity { get; set; }
        public string PosterPath { get; set; }
        public string ReleaseDate { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public decimal VoteAverage { get; set; }
        public int VoteCount { get; set; }
    }
}
