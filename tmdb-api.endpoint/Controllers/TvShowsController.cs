using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public class TvShowsController : ControllerBase
    {
        private readonly Settings _settings;
        private readonly IHttpClientService _httpClientService;
        private readonly ISearchCriteriaService _searchCriteriaService;
        private readonly ISearchResultService _searchResultService;
        private readonly ITvShowService _tvShowService;
        public TvShowsController(IOptions<Settings> settings, IHttpClientService httpClientService,
            ISearchCriteriaService searchCriteriaService, ISearchResultService searchResultService, ITvShowService tvShowService)
        {
            _settings = settings.Value;
            _httpClientService = httpClientService;
            _searchCriteriaService = searchCriteriaService;
            _searchResultService = searchResultService;
            _tvShowService = tvShowService;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchText, int userId = 1)
        {
            // There are some cases that should consider but for piloting, I'm passing those
            try
            {
                var existingSearch = await _searchCriteriaService.GetSearchCriteriaBySerachTextAsync(searchText, SearchType.TvShows.ToString());

                if (existingSearch != null)
                {
                    var existingSearchData = await _tvShowService.GetTvShows(existingSearch.Id);
                    return Ok(existingSearchData);
                }
                else
                {
                    // generate tv show search url
                    var url = GenerateUrl(searchText, true, 0);

                    var searchResult = await _httpClientService.GetAsync(url);

                    // save search criteria
                    int searchId = await _searchCriteriaService.SaveSearchCriteriaAsync(new SearchCriteria() { SearchText = searchText, SearchType = SearchType.TvShows.ToString(), UserId = userId, SearchDate = DateTime.Now });

                    // save tvShow search Json Result
                    await _searchResultService.SaveSearchResult(new SearchResult() { SearchId = searchId, SearchResultJson = searchResult });

                    // save tvshow list
                    var desirializeData = JsonConvert.DeserializeObject<TvShowSearchResult>(searchResult);

                    if (desirializeData != null && desirializeData.Results.Count > 0)
                    {
                        foreach (var tvShowData in desirializeData.Results)
                        {
                            var tvShowDbModel = new TvShow()
                            {
                                Adult = tvShowData.Adult,
                                BackdropPath = tvShowData.BackdropPath,
                                FirstAirDate = tvShowData.FirstAirDate,
                                Name = tvShowData.Name,
                                OriginalLanguage = tvShowData.OriginalLanguage,
                                OriginalName = tvShowData.OriginalName,
                                Overview = tvShowData.Overview,
                                Popularity = tvShowData.Popularity,
                                PosterPath = tvShowData.PosterPath,
                                SearchId = searchId,
                                TvShowId = tvShowData.TvShowId,
                                VoteCount = tvShowData.VoteCount
                            };

                            await _tvShowService.SaveTvShow(tvShowDbModel);
                        }
                    }

                    return Ok(desirializeData.Results);
                }

            }
            catch (Exception ex)
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
                var dbTvShowDetails = await _tvShowService.GetTvShowById(id);

                if (dbTvShowDetails != null)
                {
                    return Ok(dbTvShowDetails);
                }
                else
                {
                    string url = GenerateUrl("", false, id);
                    var movieJsonResult = await _httpClientService.GetAsync(url);
                    return Ok(JsonConvert.DeserializeObject<TvShowModel>(movieJsonResult));
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        private string GenerateUrl(string searchText, bool isTvShowSearch = true, int id = 0)
        {
            string searchUrl = string.Empty;
            string language = "en-US";

            if (isTvShowSearch)
                searchUrl = _settings.ApiBaseUrl + "search/tv" + $"?api_key={_settings.ApiKey}&language={language}&query={searchText}";
            else
                searchUrl = _settings.ApiBaseUrl + "tv/" + id + $"?api_key={_settings.ApiKey}&language={language}";

            return searchUrl;
        }

    }
}
