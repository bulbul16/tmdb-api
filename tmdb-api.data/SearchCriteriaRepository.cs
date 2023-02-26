using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tmdb_api.data.dbContext;
using tmdb_api.domain.data_interfaces;
using tmdb_api.domain.data_models;

namespace tmdb_api.data
{
    public class SearchCriteriaRepository : ISearchCriteriaRepository
    {
        private readonly TMDBApiDBContext _context;
        public SearchCriteriaRepository(TMDBApiDBContext context)
        {
            _context = context;
        }
        public async Task<SearchCriteria> GetSearchCriteriaBySerachTextAsync(string serachText, string searchType)
        {
            try
            {
                return await _context.SearchCriterias.Where(c => c.SearchText == serachText && c.SearchType == searchType).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SaveSearchCriteriaAsync(SearchCriteria searchCriteria)
        {
            try
            {
                await _context.SearchCriterias.AddAsync(searchCriteria);
                await _context.SaveChangesAsync();
                return searchCriteria.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
