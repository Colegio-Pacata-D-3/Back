using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Colegio_PacataD3.Migrations
{
    public partial class notes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ci",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdEst = table.Column<int>(nullable: false),
                    Area = table.Column<string>(nullable: true),
                    Trimester = table.Column<int>(nullable: false),
                    Ser = table.Column<int>(nullable: false),
                    Saber1 = table.Column<int>(nullable: false),
                    Saber2 = table.Column<int>(nullable: false),
                    Saber3 = table.Column<int>(nullable: false),
                    Saber4 = table.Column<int>(nullable: false),
                    Hacer1 = table.Column<int>(nullable: false),
                    Hacer2 = table.Column<int>(nullable: false),
                    Hacer3 = table.Column<int>(nullable: false),
                    Hacer4 = table.Column<int>(nullable: false),
                    Decidir = table.Column<int>(nullable: false),
                    SerE = table.Column<int>(nullable: false),
                    DecidirE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropColumn(
                name: "Ci",
                table: "Users");
        }
    }
}
