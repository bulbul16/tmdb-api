﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tmdb_api.data.dbContext;

namespace tmdb_api.data.Migrations
{
    [DbContext(typeof(TMDBApiDBContext))]
    [Migration("20230226155842_MoviesTableAdded")]
    partial class MoviesTableAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("tmdb_api.domain.data_models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Adult");

                    b.Property<string>("BackdropPath");

                    b.Property<int>("MovieId");

                    b.Property<string>("OriginalLanguage");

                    b.Property<string>("OriginalTitle");

                    b.Property<string>("Overview");

                    b.Property<string>("Popularity");

                    b.Property<string>("PosterPath");

                    b.Property<string>("ReleaseDate");

                    b.Property<int>("SearchId");

                    b.Property<string>("Title");

                    b.Property<bool>("Video");

                    b.Property<decimal>("VoteAverage");

                    b.Property<int>("VoteCount");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("tmdb_api.domain.data_models.SearchCriteria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("SearchDate");

                    b.Property<string>("SearchText");

                    b.Property<string>("SearchType");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("SearchCriterias");
                });

            modelBuilder.Entity("tmdb_api.domain.data_models.SearchResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SearchId");

                    b.Property<string>("SearchResultJson");

                    b.HasKey("Id");

                    b.ToTable("SearchResults");
                });

            modelBuilder.Entity("tmdb_api.domain.data_models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "bulbul.cse@outlook.com",
                            Name = "Bulbul Ahmed"
                        },
                        new
                        {
                            Id = 2,
                            Email = "bulbul.official@outlook.com",
                            Name = "Ahmed Abu Kawsar"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
