using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class tableadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedAt", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Electronics", new DateTime(2026, 3, 28, 10, 56, 35, 585, DateTimeKind.Local).AddTicks(2684), "Laptop", 75000m },
                    { 2, "Electronics", new DateTime(2026, 3, 28, 10, 56, 35, 585, DateTimeKind.Local).AddTicks(2689), "Mouse", 999m },
                    { 3, "Furniture", new DateTime(2026, 3, 28, 10, 56, 35, 585, DateTimeKind.Local).AddTicks(2691), "Office Chair", 8500m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
