using System;
using System.Collections.Generic;
using System.Text;

namespace tmdb_api.domain.view_models
{
    public class SearchResultViewModel
    {
        public int Id { get; set; }
        public int SearchId { get; set; }
        public string SearchResultJson { get; set; }
    }
}
