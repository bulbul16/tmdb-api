using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using tmdb_api.domain.data_interfaces;
using tmdb_api.domain.data_models;
using tmdb_api.domain.service_interfaces;

namespace tmdb_api.service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }
        public async Task<Movie> GetMovieById(int movieId)
        {
            return await _repository.GetMovieById(movieId);
        }

        public async Task<List<Movie>> GetMovies(int searchId)
        {
            return await _repository.GetMovies(searchId);
        }

        public async Task<int> SaveMovie(Movie movie)
        {
            return await _repository.SaveMovie(movie);
        }
    }
}
