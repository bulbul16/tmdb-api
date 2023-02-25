using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tmdb_api.domain.data_interfaces;
using tmdb_api.domain.data_models;
using tmdb_api.domain.service_interfaces;

namespace tmdb_api.service
{
    public class SearchResultService : ISearchResultService
    {
        private readonly ISearchResultRepository _repository;
        public SearchResultService(ISearchResultRepository repository)
        {
            _repository = repository;
        }

        public async Task<SearchResult> GetSearchResultBySearchIdAsync(int searchId)
        {
            return await _repository.GetSearchResultBySearchIdAsync(searchId);
        }

        public Task<List<SearchResult>> GetSearchResultsAsync()
        {
            return _repository.GetSearchResultsAsync();
        }

        public async Task<int> SaveSearchResult(SearchResult searchResult)
        {
            return await _repository.SaveSearchResult(searchResult);
        }
    }
}
