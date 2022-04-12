using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApplication.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    ExpirityDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Shop1" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Shop2" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Shop3" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "ExpirityDate", "Name", "ShopId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 12, 16, 16, 52, 25, 253, DateTimeKind.Utc).AddTicks(5009), "Item1", 1 },
                    { 2, new DateTime(2021, 12, 16, 16, 52, 25, 253, DateTimeKind.Utc).AddTicks(5859), "Item2", 1 },
                    { 3, new DateTime(2021, 12, 16, 16, 52, 25, 253, DateTimeKind.Utc).AddTicks(5862), "Item3", 1 },
                    { 4, new DateTime(2021, 12, 16, 16, 52, 25, 253, DateTimeKind.Utc).AddTicks(5863), "Item4", 2 },
                    { 5, new DateTime(2021, 12, 16, 16, 52, 25, 253, DateTimeKind.Utc).AddTicks(5864), "Item5", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShopId",
                table: "Items",
                column: "ShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
