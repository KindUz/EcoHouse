using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoHouse.Storage.Migrations
{
    public partial class NB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_dishes_DishID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Orders_OrdersID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_OrdersID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DishID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrdersID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DishID",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrdersID",
                table: "dishes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_dishes_OrdersID",
                table: "dishes",
                column: "OrdersID");

            migrationBuilder.AddForeignKey(
                name: "FK_dishes_Orders_OrdersID",
                table: "dishes",
                column: "OrdersID",
                principalTable: "Orders",
                principalColumn: "OrdersID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserID",
                table: "Orders",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dishes_Orders_OrdersID",
                table: "dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_dishes_OrdersID",
                table: "dishes");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrdersID",
                table: "dishes");

            migrationBuilder.AddColumn<int>(
                name: "OrdersID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DishID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrdersID",
                table: "Users",
                column: "OrdersID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DishID",
                table: "Orders",
                column: "DishID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_dishes_DishID",
                table: "Orders",
                column: "DishID",
                principalTable: "dishes",
                principalColumn: "Dish_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Orders_OrdersID",
                table: "Users",
                column: "OrdersID",
                principalTable: "Orders",
                principalColumn: "OrdersID");
        }
    }
}
