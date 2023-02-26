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
    public class TvShowRepository : ITvShowRepository
    {
        private readonly TMDBApiDBContext _context;
        public TvShowRepository(TMDBApiDBContext context)
        {
            _context = context;
        }
        public async Task<TvShow> GetTvShowById(int tvShowId)
        {
            try
            {
                var tvShow = await _context.TvShows.Where(c => c.TvShowId == tvShowId).FirstOrDefaultAsync();
                return tvShow;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<TvShow>> GetTvShows(int searchId)
        {
            try
            {
                var tvShowList = await _context.TvShows.Where(c => c.SearchId == searchId).ToListAsync();
                return tvShowList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SaveTvShow(TvShow tvShow)
        {
            try
            {
                await _context.TvShows.AddAsync(tvShow);
                await _context.SaveChangesAsync();
                return tvShow.Id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
