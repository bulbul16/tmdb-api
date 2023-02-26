using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using tmdb_api.domain.configuration;
using tmdb_api.domain.data_models;
using tmdb_api.domain.enums;
using tmdb_api.domain.service_interfaces;
using tmdb_api.endpoint.Helper;
using tmdb_api.service;

namespace tmdb_api.endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly Settings _settings;
        private readonly IHttpClientService _httpClientService;
        private readonly ISearchCriteriaService _searchCriteriaService;
        private readonly ISearchResultService _searchResultService;
        private readonly IMovieService _movieService;
        public MovieController(IOptions<Settings> settings, IHttpClientService httpClientService,
            ISearchCriteriaService searchCriteriaService, ISearchResultService searchResultService, IMovieService movieService)
        {
            _settings = settings.Value;
            _httpClientService = httpClientService;
            _searchCriteriaService = searchCriteriaService;
            _searchResultService = searchResultService;
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchText, int userId = 1)
        {
            // There are some cases that should consider but for piloting, I'm passing those
            try
            {
                var existingSearch = await _searchCriteriaService.GetSearchCriteriaBySerachTextAsync(searchText, SearchType.Movie.ToString());

                if (existingSearch != null)
                {
                    var existingSearchData = await _movieService.GetMovies(existingSearch.Id);
                    return Ok(existingSearchData);
                }
                else
                {
                    // generate movie search url
                    var url = GenerateUrl(searchText, true, 0);

                    var searchResult = await _httpClientService.GetAsync(url);

                    // save search criteria
                    int searchId = await _searchCriteriaService.SaveSearchCriteriaAsync(new SearchCriteria() { SearchText = searchText, SearchType = SearchType.Movie.ToString(), UserId = userId, SearchDate = DateTime.Now });

                    // save movie search Json Result
                    await _searchResultService.SaveSearchResult(new SearchResult() { SearchId = searchId, SearchResultJson = searchResult });

                    // save movie list
                    var desirializeData = JsonConvert.DeserializeObject<MovieSearchResult>(searchResult);

                    if (desirializeData != null && desirializeData.Results.Count > 0)
                    {
                        foreach (var movieData in desirializeData.Results)
                        {
                            var movieDbModel = new Movie()
                            {
                                MovieId = movieData.MovieId,
                                Adult = movieData.Adult,
                                BackdropPath = movieData.BackdropPath,
                                OriginalLanguage = movieData.OriginalLanguage,
                                OriginalTitle = movieData.OriginalTitle,
                                Overview = movieData.Overview,
                                Popularity = movieData.Popularity,
                                PosterPath = movieData.PosterPath,
                                ReleaseDate = movieData.ReleaseDate,
                                SearchId = searchId,
                                Title = movieData.Title,
                                Video = movieData.Video,
                                VoteAverage = movieData.VoteAverage,
                                VoteCount = movieData.VoteCount
                            };

                            await _movieService.SaveMovie(movieDbModel);
                        }
                    }
                    return Ok(desirializeData.Results);
                }

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            // Need to check some corner cases here, for now I'm passing those
            try
            {
                var dbMovieDetails = await _movieService.GetMovieById(id);

                if (dbMovieDetails != null)
                {
                    return Ok(dbMovieDetails);
                }
                else
                {
                    string url = GenerateUrl("", false, id);
                    var movieJsonResult = await _httpClientService.GetAsync(url);
                    return Ok(JsonConvert.DeserializeObject<MovieModel>(movieJsonResult));
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        private string GenerateUrl(string searchText, bool isMovieSearch = true, int id = 0)
        {
            string searchUrl = string.Empty;
            string language = "en-US";
            int pageNumber = 1;
            bool includeAdult = true;

            if (isMovieSearch)
                searchUrl = _settings.ApiBaseUrl + "search/movie" + $"?api_key={_settings.ApiKey}&language={language}&page={pageNumber}&include_adult={includeAdult}&query={searchText}";
            else
                searchUrl = _settings.ApiBaseUrl + "movie/" + id + $"?api_key={_settings.ApiKey}&language={language}";

            return searchUrl;
        }

    }
}
