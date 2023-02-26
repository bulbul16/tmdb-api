using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using tmdb_api.data.dbContext;
using tmdb_api.domain.data_interfaces;

namespace tmdb_api.data
{
    public static class DataDependencyResolver
    {
        public static IServiceCollection AddDBServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<TMDBApiDBContext>(option => option.UseSqlServer(configuration.GetConnectionString("TMDB")));
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<ISearchCriteriaRepository, SearchCriteriaRepository>();
            service.AddScoped<ISearchResultRepository, SearchResultRepository>();

            service.AddScoped<IMovieRepository, MovieRepository>();
            service.AddScoped<IPeopleRepository, PeopleRepository>();
            service.AddScoped<IMovieRepository, MovieRepository>();
            return service;
        }
    }
}
