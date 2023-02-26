using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tmdb_api.data.dbContext;
using tmdb_api.domain.data_interfaces;
using tmdb_api.domain.data_models;

namespace tmdb_api.data
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly TMDBApiDBContext _context;
        public PeopleRepository(TMDBApiDBContext context)
        {
            _context= context;
        }
        public async Task<People> GetPeopleById(int peopleId)
        {
            try
            {
                var movie = await _context.Peoples.Where(c => c.PeopleId == peopleId).FirstOrDefaultAsync();
                return movie;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<People>> GetPeoples(int searchId)
        {
            try
            {
                var peopleList = await _context.Peoples.Where(c => c.SearchId == searchId).ToListAsync();
                return peopleList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SavePeople(People people)
        {
            try
            {
                await _context.Peoples.AddAsync(people);
                await _context.SaveChangesAsync();
                return people.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
