using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopOnline.IDP.Migrations
{
    public partial class Create_Permission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Permisions",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Function = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Command = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    RoleId = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permisions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Permisions_RoleId_Function_Command",
                schema: "Identity",
                table: "Permisions",
                columns: new[] { "RoleId", "Function", "Command" },
                unique: true,
                filter: "[RoleId] IS NOT NULL AND [Function] IS NOT NULL AND [Command] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permisions",
                schema: "Identity");

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
                values: new object[] { "4d3ae25c-a1f4-4110-8260-876e613a937d", "7ff6a3b0-e466-4a51-8a17-de8c4c45c5ac", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac24abd9-2e09-44e3-b06b-eb30366550ad", "13b8d996-f592-421c-a895-c12c5ac2ef57", "Customer", "CUSTOMER" });
        }
    }
}
