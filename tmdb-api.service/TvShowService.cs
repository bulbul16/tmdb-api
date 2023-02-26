using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tmdb_api.domain.data_models;
using tmdb_api.domain.service_interfaces;

namespace tmdb_api.service
{
    public class TvShowService : ITvShowService
    {
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
