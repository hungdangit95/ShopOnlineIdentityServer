using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopOnline.IDP.Migrations
{
    public partial class CreatePermissionTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1c2ec192-99e5-466a-81a0-c31559b96ca1");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6df77ab9-7ab0-4e99-9678-969fbd25b0a7");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c2e725d-6aab-47fd-b860-df8b0af5c886", "ab3f1301-e4cc-491c-a6d3-0cf918dc587d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "91944640-d01d-4649-a22b-e7b57c53702b", "47431655-7d92-40b2-b224-5bef09290165", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4c2e725d-6aab-47fd-b860-df8b0af5c886");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "91944640-d01d-4649-a22b-e7b57c53702b");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1c2ec192-99e5-466a-81a0-c31559b96ca1", "db80aed2-abbe-4778-8fa9-613c7af904b9", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6df77ab9-7ab0-4e99-9678-969fbd25b0a7", "c4ca88c2-0e4c-4e16-908e-75327bc6c896", "Administrator", "ADMINISTRATOR" });
        }
    }
}
