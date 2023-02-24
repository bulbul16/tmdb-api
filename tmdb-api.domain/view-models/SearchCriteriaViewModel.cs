﻿using System;
using System.Collections.Generic;
using System.Text;

namespace tmdb_api.domain.view_models
{
    public class SearchCriteriaViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SearchType { get; set; }
        public string SearchText { get; set; }
        public DateTime? SearchDate { get; set; }
    }
}
