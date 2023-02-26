using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tmdb_api.data.Migrations
{
    public partial class MoviesTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SearchId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    Adult = table.Column<bool>(nullable: false),
                    BackdropPath = table.Column<string>(nullable: true),
                    OriginalLanguage = table.Column<string>(nullable: true),
                    OriginalTitle = table.Column<string>(nullable: true),
                    Overview = table.Column<string>(nullable: true),
                    Popularity = table.Column<string>(nullable: true),
                    PosterPath = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Video = table.Column<bool>(nullable: false),
                    VoteAverage = table.Column<decimal>(nullable: false),
                    VoteCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
