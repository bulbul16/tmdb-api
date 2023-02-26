using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tmdb_api.domain.data_interfaces;
using tmdb_api.domain.data_models;
using tmdb_api.domain.service_interfaces;

namespace tmdb_api.service
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _repository;
        public PeopleService(IPeopleRepository repository)
        {
            _repository = repository;
        }
        public async Task<People> GetPeopleById(int peopleId)
        {
            return await _repository.GetPeopleById(peopleId);
        }

        public async Task<List<People>> GetPeoples(int searchId)
        {
            return await _repository.GetPeoples(searchId);
        }

        public async Task<int> SavePeople(People people)
        {
            return await _repository.SavePeople(people);
        }
    }
}
