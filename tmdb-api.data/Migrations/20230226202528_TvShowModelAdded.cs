using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tmdb_api.data.Migrations
{
    public partial class TvShowModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TvShows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TvShowId = table.Column<int>(nullable: false),
                    SearchId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OriginalName = table.Column<string>(nullable: true),
                    OriginalLanguage = table.Column<string>(nullable: true),
                    Adult = table.Column<bool>(nullable: false),
                    BackdropPath = table.Column<string>(nullable: true),
                    FirstAirDate = table.Column<string>(nullable: true),
                    Overview = table.Column<string>(nullable: true),
                    Popularity = table.Column<decimal>(nullable: false),
                    PosterPath = table.Column<string>(nullable: true),
                    VoteAverage = table.Column<decimal>(nullable: false),
                    VoteCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShows", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TvShows");
        }
    }
}
