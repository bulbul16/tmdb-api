using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tmdb_api.domain.data_models;

namespace tmdb_api.domain.data_interfaces
{
    public interface ISearchCriteriaRepository
    {
        Task<int> SaveSearchCriteriaAsync(SearchCriteria searchCriteria);
        Task<List<SearchCriteria>> GetSearchCriteriaBySerachTextAsync(string serachText, int userId);

    }
}
