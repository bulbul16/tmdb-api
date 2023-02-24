﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tmdb_api.domain.data_models;

namespace tmdb_api.domain.data_interfaces
{
    public interface ISearchCriteriaRepository
    {
        Task SaveSearchCriteriaAsync();
        Task<SearchCriteria> GetSearchCriteriaBySerachTextAsync(string serachText);

    }
}
