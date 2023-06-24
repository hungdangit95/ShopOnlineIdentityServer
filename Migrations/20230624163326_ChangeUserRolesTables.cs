using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopOnline.IDP.Migrations
{
    public partial class ChangeUserRolesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a5483837-a361-499a-a37e-0f8d5c812314");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e2250840-cef5-43bb-a959-51f37d818c76");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                schema: "Identity",
                table: "UserRoles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4d3ae25c-a1f4-4110-8260-876e613a937d", "7ff6a3b0-e466-4a51-8a17-de8c4c45c5ac", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac24abd9-2e09-44e3-b06b-eb30366550ad", "13b8d996-f592-421c-a895-c12c5ac2ef57", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4d3ae25c-a1f4-4110-8260-876e613a937d");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ac24abd9-2e09-44e3-b06b-eb30366550ad");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                schema: "Identity",
                table: "UserRoles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                schema: "Identity",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a5483837-a361-499a-a37e-0f8d5c812314", "1cae60bc-33da-4cb0-b9b5-915f1da2cd39", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e2250840-cef5-43bb-a959-51f37d818c76", "3d4744a9-4e71-4ba0-ba69-8c9f014b97bd", "Administrator", "ADMINISTRATOR" });
        }
    }
}
