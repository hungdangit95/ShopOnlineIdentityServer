using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopOnline.IDP.Migrations
{
    public partial class CreatePermissionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "19a3f3fe-89e0-48e5-9183-48643854db90");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4f69253e-c061-46c5-b3ed-ac38ed090738");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "19a3f3fe-89e0-48e5-9183-48643854db90", "2317ffa9-b434-4ef7-95aa-840fbae36d27", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4f69253e-c061-46c5-b3ed-ac38ed090738", "bfd39bf3-db4d-4c12-8033-13c4a43c5d59", "Customer", "CUSTOMER" });
        }
    }
}
