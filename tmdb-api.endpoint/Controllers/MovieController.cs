using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using tmdb_api.domain.configuration;
using tmdb_api.domain.data_models;
using tmdb_api.domain.enums;
using tmdb_api.domain.service_interfaces;

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
        public MovieController(IOptions<Settings> settings, IHttpClientService httpClientService,
            ISearchCriteriaService searchCriteriaService, ISearchResultService searchResultService)
        {
            _settings = settings.Value;
            _httpClientService = httpClientService;
            _searchCriteriaService = searchCriteriaService;
            _searchResultService = searchResultService;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchText, int userId = 1)
        {
            try
            {
                var existingSearch = await _searchCriteriaService.GetSearchCriteriaBySerachTextAsync(searchText, userId);

                if (existingSearch != null && existingSearch.Count > 0)
                {
                    var existingSearchData = await _searchResultService.GetSearchResultBySearchIdAsync(existingSearch[0].Id);
                    return Ok(existingSearchData.SearchResultJson);
                }
                else
                {
                    // generate movie search url
                    var url = GenerateUrl(searchText);
                    var searchResult = await _httpClientService.GetAsync(url);

                    // save search criteria
                    int searchId = await _searchCriteriaService.SaveSearchCriteriaAsync(new SearchCriteria() { SearchText = searchText, SearchType = SearchType.Movie.ToString(), UserId = userId, SearchDate = DateTime.Now });

                    // save searchResult
                    await _searchResultService.SaveSearchResult(new SearchResult() { SearchId = searchId, SearchResultJson = searchResult });

                    return Ok(searchResult);
                }

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        private string GenerateUrl(string searchText)
        {
            string language = "en-US";
            int pageNumber = 1;
            bool includeAdult = true;

            string url = _settings.ApiBaseUrl + "search/movie" + $"?api_key={_settings.ApiKey}&language={language}&page={pageNumber}&include_adult={includeAdult}&query={searchText}";
            return url;
        }

    }
}
