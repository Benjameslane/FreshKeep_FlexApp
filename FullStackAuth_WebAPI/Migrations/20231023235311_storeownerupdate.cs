using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class storeownerupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a62e6ca-452c-4eb9-9587-1c1864861e0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5f04f94-0ab6-4456-aa99-bac9e79345ca");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "337d0c4d-e4b1-48c7-bd84-c9a0f88b0f39", null, "User", "USER" },
                    { "ca9ebd74-b2c0-4fa3-a3b8-5984f3589420", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "337d0c4d-e4b1-48c7-bd84-c9a0f88b0f39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca9ebd74-b2c0-4fa3-a3b8-5984f3589420");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8a62e6ca-452c-4eb9-9587-1c1864861e0d", null, "Admin", "ADMIN" },
                    { "e5f04f94-0ab6-4456-aa99-bac9e79345ca", null, "User", "USER" }
                });
        }
    }
}
