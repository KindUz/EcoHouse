using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoHouse.Storage.Migrations
{
    public partial class NBB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Deliveries_Delivery_ID",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Delivery_ID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Delivery_ID",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "Address_ID",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Address_ID",
                table: "Orders",
                column: "Address_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Another_Adresses_Address_ID",
                table: "Orders",
                column: "Address_ID",
                principalTable: "Another_Adresses",
                principalColumn: "Address_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Another_Adresses_Address_ID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Address_ID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Address_ID",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "Delivery_ID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    DeliveryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    Term = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.DeliveryId);
                    table.ForeignKey(
                        name: "FK_Deliveries_Another_Adresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Another_Adresses",
                        principalColumn: "Address_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Delivery_ID",
                table: "Orders",
                column: "Delivery_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_AddressID",
                table: "Deliveries",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Deliveries_Delivery_ID",
                table: "Orders",
                column: "Delivery_ID",
                principalTable: "Deliveries",
                principalColumn: "DeliveryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
