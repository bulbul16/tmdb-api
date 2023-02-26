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
    public class MovieRepository : IMovieRepository
    {
        private readonly TMDBApiDBContext _context;
        public MovieRepository(TMDBApiDBContext context)
        {
            _context = context;
        }

        public async Task<Movie> GetMovieById(int movieId)
        {
            try
            {
                var movie = await _context.Movies.Where(c => c.MovieId == movieId).FirstOrDefaultAsync();
                return movie;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Movie>> GetMovies(int searchId)
        {
            try
            {
                var movieList = await _context.Movies.Where(c => c.SearchId == searchId).ToListAsync();
                return movieList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SaveMovie(Movie movie)
        {
            try
            {
                await _context.Movies.AddAsync(movie);
                await _context.SaveChangesAsync();
                return movie.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
