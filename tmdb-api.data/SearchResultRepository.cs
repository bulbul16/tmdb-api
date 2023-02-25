using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tmdb_api.data.dbContext;
using tmdb_api.domain.data_interfaces;
using tmdb_api.domain.data_models;

namespace tmdb_api.data
{
    public class SearchResultRepository : ISearchResultRepository
    {
        private readonly TMDBApiDBContext _context;
        public SearchResultRepository(TMDBApiDBContext context)
        {
            _context = context;
        }
        public async Task<SearchResult> GetSearchResultBySearchIdAsync(int serachId)
        {
            try
            {
                return await _context.SearchResults.FindAsync(serachId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SearchResult>> GetSearchResultsAsync()
        {
            try
            {
                return await _context.SearchResults.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SaveSearchResult(SearchResult searchResult)
        {
            try
            {
                await _context.SearchResults.AddAsync(searchResult);
                await _context.SaveChangesAsync();
                return searchResult.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
