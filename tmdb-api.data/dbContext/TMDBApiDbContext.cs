using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using tmdb_api.domain.data_models;

namespace tmdb_api.data.dbContext
{
    public class TMDBApiDBContext : DbContext
    {
        public TMDBApiDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SearchCriteria> SearchCriterias { get; set; }
        public DbSet<SearchResult> SearchResults { get; set; }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<People> Peoples { get; set; }
        //public DbSet<TvShow> TvShows { get; set; }

    }
}
