using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tmdb_api.data.Migrations
{
    public partial class PeopleModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peoples",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PeopleId = table.Column<int>(nullable: false),
                    SearchId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OriginalName = table.Column<string>(nullable: true),
                    Adult = table.Column<bool>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    KnownFor = table.Column<string>(nullable: true),
                    KnownForDepartment = table.Column<string>(nullable: true),
                    Popularity = table.Column<decimal>(nullable: false),
                    ProfilePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peoples");
        }
    }
}
