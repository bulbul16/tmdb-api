using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using tmdb_api.domain.service_interfaces;

namespace tmdb_api.service
{
    public static class ServiceDependencyResolver
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection service)
        {
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<ISearchCriteriaService, SearchCriteriaService>();
            service.AddScoped<ISearchResultService, SearchResultService>();
            service.AddScoped<IHttpClientService, HttpClientService>();

            service.AddScoped<IMovieService, MovieService>();
            service.AddScoped<IPeopleService, PeopleService>();
            service.AddScoped<ITvShowService, TvShowService>();
            return service;
        }
    }
}
