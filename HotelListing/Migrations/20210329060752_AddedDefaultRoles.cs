using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelListing.Migrations
{
    public partial class AddedDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bd4f14ab-ae7c-4de0-88ae-c6de83fe1e32", "ce7e4b0b-6304-4488-b611-057a1d7a8d9f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "47999840-d071-497e-a5f9-8d0e63ac36e8", "2ec5d4d1-6404-411c-b05c-783c1e8c16c9", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47999840-d071-497e-a5f9-8d0e63ac36e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd4f14ab-ae7c-4de0-88ae-c6de83fe1e32");
        }
    }
}
