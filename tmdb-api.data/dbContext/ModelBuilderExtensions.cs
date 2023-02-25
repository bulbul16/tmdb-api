using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using tmdb_api.domain.data_models;

namespace tmdb_api.data.dbContext
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Bulbul Ahmed",
                    Email = "bulbul.cse@outlook.com"
                },
                new User
                {
                    Id = 2,
                    Name = "Ahmed Abu Kawsar",
                    Email = "bulbul.official@outlook.com"
                }
            );
        }
    }
}
