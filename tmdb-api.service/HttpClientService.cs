using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using tmdb_api.domain.service_interfaces;

namespace tmdb_api.service
{
    public class HttpClientService : IHttpClientService
    {
        public async Task<string> GetAsync(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
