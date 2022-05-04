using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoHouse.Storage.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "processes",
                columns: table => new
                {
                    Process_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Recipe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_processes", x => x.Process_ID);
                });

            migrationBuilder.CreateTable(
                name: "structures",
                columns: table => new
                {
                    Structure_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Proteins = table.Column<float>(type: "real", nullable: false),
                    Fats = table.Column<float>(type: "real", nullable: false),
                    Carbohydrates = table.Column<float>(type: "real", nullable: false),
                    Calorific = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_structures", x => x.Structure_ID);
                });

            migrationBuilder.CreateTable(
                name: "dishes",
                columns: table => new
                {
                    Dish_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Structure_ = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Mass = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Process_ = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dishes", x => x.Dish_ID);
                    table.ForeignKey(
                        name: "FK_dishes_processes_Process_",
                        column: x => x.Process_,
                        principalTable: "processes",
                        principalColumn: "Process_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dishes_structures_Structure_",
                        column: x => x.Structure_,
                        principalTable: "structures",
                        principalColumn: "Structure_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dishes_Process_",
                table: "dishes",
                column: "Process_");

            migrationBuilder.CreateIndex(
                name: "IX_dishes_Structure_",
                table: "dishes",
                column: "Structure_");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dishes");

            migrationBuilder.DropTable(
                name: "processes");

            migrationBuilder.DropTable(
                name: "structures");
        }
    }
}
