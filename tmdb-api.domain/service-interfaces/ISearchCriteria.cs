﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tmdb_api.domain.data_models;

namespace tmdb_api.domain.service_interfaces
{
	public interface ISearchCriteria
	{
		Task SaveSearchCriteriaAsync();
		Task<SearchCriteria> GetSearchCriteriaBySerachTextAsync(string serachText);

	}
}
