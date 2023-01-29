using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelListing.Migrations
{
    public partial class dataseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "countries",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[] { 1, "India", "Ind" });

            migrationBuilder.InsertData(
                table: "countries",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[] { 2, "Pakistan", "Pak" });

            migrationBuilder.InsertData(
                table: "countries",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[] { 3, "Nepal", "Nep" });

            migrationBuilder.InsertData(
                table: "hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "Rating" },
                values: new object[] { 1, "patna", 1, "patna hotel", 4.5 });

            migrationBuilder.InsertData(
                table: "hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "Rating" },
                values: new object[] { 2, "peshawar", 2, "peshawar hotel", 4.2999999999999998 });

            migrationBuilder.InsertData(
                table: "hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "Rating" },
                values: new object[] { 3, "kathmandu", 3, "kathmandu hotel", 4.2000000000000002 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
