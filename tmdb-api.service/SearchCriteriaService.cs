using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using tmdb_api.domain.data_interfaces;
using tmdb_api.domain.data_models;
using tmdb_api.domain.service_interfaces;

namespace tmdb_api.service
{
    public class SearchCriteriaService : ISearchCriteriaService
    {
        private readonly ISearchCriteriaRepository _repository;
        public SearchCriteriaService(ISearchCriteriaRepository repository)
        {
            _repository = repository;
        }
        public async Task<SearchCriteria> GetSearchCriteriaBySerachTextAsync(string serachText, string searchType)
        {
            return await _repository.GetSearchCriteriaBySerachTextAsync(serachText, searchType);
        }

        public async Task<int> SaveSearchCriteriaAsync(SearchCriteria searchCriteria)
        {
            return await _repository.SaveSearchCriteriaAsync(searchCriteria);
        }
    }
}
