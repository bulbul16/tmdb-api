using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tmdb_api.domain.data_interfaces;
using tmdb_api.domain.data_models;
using tmdb_api.domain.service_interfaces;

namespace tmdb_api.service
{
    public class TvShowService : ITvShowService
    {
        private readonly ITvShowRepository _repository;
        public TvShowService(ITvShowRepository repository)
        {
            _repository= repository;
        }
        public async Task<TvShow> GetTvShowById(int tvShowId)
        {
            return await _repository.GetTvShowById(tvShowId);
        }

        public async Task<List<TvShow>> GetTvShows(int searchId)
        {
            return await _repository.GetTvShows(searchId);
        }

        public async Task<int> SaveTvShow(TvShow tvShow)
        {
            return await _repository.SaveTvShow(tvShow);
        }
    }
}
