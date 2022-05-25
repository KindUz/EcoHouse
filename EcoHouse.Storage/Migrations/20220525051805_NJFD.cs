using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoHouse.Storage.Migrations
{
    public partial class NJFD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Users",
                newName: "Path");

            migrationBuilder.AddColumn<string>(
                name: "Name_Photo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name_Photo",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Users",
                newName: "Photo");
        }
    }
}
