using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
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
    public class PeopleController : ControllerBase
    {
        private readonly Settings _settings;
        private readonly IHttpClientService _httpClientService;
        private readonly ISearchCriteriaService _searchCriteriaService;
        private readonly ISearchResultService _searchResultService;
        private readonly IPeopleService _peopleService;
        public PeopleController(IOptions<Settings> settings, IHttpClientService httpClientService,
            ISearchCriteriaService searchCriteriaService, ISearchResultService searchResultService, IPeopleService peopleService)
        {
            _settings = settings.Value;
            _httpClientService = httpClientService;
            _searchCriteriaService = searchCriteriaService;
            _searchResultService = searchResultService;
            _peopleService = peopleService;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchText, int userId = 1)
        {
            // There are some cases that should consider but for piloting, I'm passing those
            try
            {
                var existingSearch = await _searchCriteriaService.GetSearchCriteriaBySerachTextAsync(searchText, SearchType.People.ToString());

                if (existingSearch != null)
                {
                    var existingSearchData = await _peopleService.GetPeoples(existingSearch.Id);
                    return Ok(existingSearchData);
                }
                else
                {
                    // generate movie search url
                    var url = GenerateUrl(searchText, true, 0);

                    var searchResult = await _httpClientService.GetAsync(url);

                    // save search criteria
                    int searchId = await _searchCriteriaService.SaveSearchCriteriaAsync(new SearchCriteria() { SearchText = searchText, SearchType = SearchType.People.ToString(), UserId = userId, SearchDate = DateTime.Now });

                    // save people search Json Result
                    await _searchResultService.SaveSearchResult(new SearchResult() { SearchId = searchId, SearchResultJson = searchResult });

                    // save people list
                    var desirializeData = JsonConvert.DeserializeObject<PeopleSearchResult>(searchResult);

                    if (desirializeData != null && desirializeData.Results.Count > 0)
                    {
                        foreach (var movieData in desirializeData.Results)
                        {
                            var peopleDbModel = new People()
                            {
                                Adult = movieData.Adult,
                                Gender = movieData.Gender,
                                //KnownFor = movieData.KnownFor,
                                Name = movieData.Name,
                                KnownForDepartment = movieData.KnownForDepartment,
                                OriginalName = movieData.OriginalName,
                                PeopleId = movieData.PeopleId,
                                Popularity = movieData.Popularity,
                                ProfilePath = movieData.ProfilePath,
                                SearchId = searchId
                            };

                            await _peopleService.SavePeople(peopleDbModel);
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
                var dbPeopleDetails = await _peopleService.GetPeopleById(id);

                if (dbPeopleDetails != null)
                {
                    return Ok(dbPeopleDetails);
                }
                else
                {
                    string url = GenerateUrl("", false, id);
                    var movieJsonResult = await _httpClientService.GetAsync(url);
                    return Ok(JsonConvert.DeserializeObject<PeopleModel>(movieJsonResult));
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        private string GenerateUrl(string searchText, bool isPeopleSearch = true, int id = 0)
        {
            string searchUrl = string.Empty;
            string language = "en-US";
            int pageNumber = 1;
            bool includeAdult = true;

            if (isPeopleSearch)
                searchUrl = _settings.ApiBaseUrl + "search/person" + $"?api_key={_settings.ApiKey}&language={language}&page={pageNumber}&include_adult={includeAdult}&query={searchText}";
            else
                searchUrl = _settings.ApiBaseUrl + "person/" + id + $"?api_key={_settings.ApiKey}&language={language}";

            return searchUrl;
        }
    }
}
