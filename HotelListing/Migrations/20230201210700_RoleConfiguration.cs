using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelListing.Migrations
{
    public partial class RoleConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "807c9012-ad0c-40b3-9274-03280874d90a", "8eba11ad-4125-45ff-8ab7-292d2067f411", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca642ccf-8e79-476e-955e-00b04d8373e7", "9e44764c-9250-41fb-a9c0-3177f8727caa", "Adminstrator", "ADMINSTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "807c9012-ad0c-40b3-9274-03280874d90a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca642ccf-8e79-476e-955e-00b04d8373e7");
        }
    }
}
