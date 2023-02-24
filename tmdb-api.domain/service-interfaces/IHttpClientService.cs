using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace tmdb_api.domain.service_interfaces
{
    public interface IHttpClientService
    {
        Task<string> GetAsync(string url);
    }
}
