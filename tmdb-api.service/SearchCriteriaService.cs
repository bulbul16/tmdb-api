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
        public async Task<List<SearchCriteria>> GetSearchCriteriaBySerachTextAsync(string serachText, int userId)
        {
            return await _repository.GetSearchCriteriaBySerachTextAsync(serachText, userId);
        }

        public async Task SaveSearchCriteriaAsync(SearchCriteria searchCriteria)
        {
            await _repository.SaveSearchCriteriaAsync(searchCriteria);
        }
    }
}
