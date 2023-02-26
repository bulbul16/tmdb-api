using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tmdb_api.domain.data_models;

namespace tmdb_api.domain.data_interfaces
{
    public interface ITvShowRepository
    {
        Task<List<TvShow>> GetTvShows(int searchId);
        Task<TvShow> GetTvShowById(int tvShowId);
        Task<int> SaveTvShow(TvShow tvShow);
    }
}
