using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tmdb_api.domain.data_models;

namespace tmdb_api.domain.data_interfaces
{
    public interface ISearchResultRepository
    {
        Task<List<SearchResult>> GetSearchResultsAsync();
        Task<SearchResult> GetSearchResultBySearchIdAsync(int serachId);
        Task<int> SaveSearchResult(SearchResult searchResult);
    }
}
