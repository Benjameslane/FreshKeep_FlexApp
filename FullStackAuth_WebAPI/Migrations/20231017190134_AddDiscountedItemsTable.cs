using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDiscountedItemsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "043d3af1-ab1d-490f-94d9-d6c7ac8aca36");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23bfa8e6-acf0-411b-9268-de9bf802c9b7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a8afb44-28f1-42c2-a654-5b5d53070f22", null, "User", "USER" },
                    { "4aa0719f-0a2a-4a1f-a07f-6728f02e0169", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a8afb44-28f1-42c2-a654-5b5d53070f22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4aa0719f-0a2a-4a1f-a07f-6728f02e0169");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "043d3af1-ab1d-490f-94d9-d6c7ac8aca36", null, "Admin", "ADMIN" },
                    { "23bfa8e6-acf0-411b-9268-de9bf802c9b7", null, "User", "USER" }
                });
        }
    }
}
