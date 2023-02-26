using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tmdb_api.domain.data_models;

namespace tmdb_api.domain.service_interfaces
{
    public interface IPeopleService
    {
        Task<List<People>> GetPeoples(int searchId);
        Task<People> GetPeopleById(int peopleId);
        Task<int> SavePeople(People people);
    }
}
