using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiInAsp.netcoreMvcDemo.Migrations
{
    /// <inheritdoc />
    public partial class initialcommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21511b62-f9b7-4e19-9515-4850e73dec3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cd2bfba-fd34-4a00-b166-ceff8fa1ca57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c97d0e2-c0d9-4b3c-9f4e-333f7214c01d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "24c540e5-b189-4ae1-993b-c4e894e66cb5", "1", "Admin", "Admin" },
                    { "aba4b61a-d810-49ca-a31a-251da80a5fad", "2", "User", "User" },
                    { "f283646d-eff2-4365-93aa-029e1843d24e", "3", "HR", "HR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24c540e5-b189-4ae1-993b-c4e894e66cb5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aba4b61a-d810-49ca-a31a-251da80a5fad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f283646d-eff2-4365-93aa-029e1843d24e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21511b62-f9b7-4e19-9515-4850e73dec3b", "2", "User", "User" },
                    { "4cd2bfba-fd34-4a00-b166-ceff8fa1ca57", "1", "Admin", "Admin" },
                    { "5c97d0e2-c0d9-4b3c-9f4e-333f7214c01d", "3", "HR", "HR" }
                });
        }
    }
}
