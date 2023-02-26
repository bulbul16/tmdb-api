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
        public Task<TvShow> GetTvShowById(int tvShowId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TvShow>> GetTvShows(int searchId)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveTvShow(TvShow tvShow)
        {
            throw new NotImplementedException();
        }
    }
}
