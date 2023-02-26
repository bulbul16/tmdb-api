using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tmdb_api.domain.data_models;

namespace tmdb_api.domain.data_interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetMovies(int searchId);
        Task<Movie> GetMovieById(int movieId);
        Task<int> SaveMovie(Movie movie);
    }
}
