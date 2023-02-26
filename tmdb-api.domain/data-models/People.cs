using System;
using System.Collections.Generic;
using System.Text;

namespace tmdb_api.domain.data_models
{
    public class People
    {
        public int Id { get; set; }
        public int PeopleId { get; set; }
        public int SearchId { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public bool Adult { get; set; }
        public int Gender { get; set; }
        public string KnownFor { get; set; }
        public string KnownForDepartment { get; set; }
        public decimal Popularity { get; set; }
        public string ProfilePath { get; set; }
    }
}
