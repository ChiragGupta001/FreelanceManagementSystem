using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class initialiseServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Service = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicesAvailable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serviceTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesAvailable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicesAvailable_ServiceTypes_serviceTypeId",
                        column: x => x.serviceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94d5a42a-076a-440d-b57c-d2fca8896085",
                column: "ConcurrencyStamp",
                value: "4335a3a6-efaf-44e3-a93e-b8fbef38274e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db45eba7-bfea-4bb7-a6a8-45ae1a59e9a0",
                column: "ConcurrencyStamp",
                value: "53cfa6c8-4e15-4d2a-9a1d-c0adefd93dca");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4d913ae6-b161-446d-9759-2145d277c1d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f88e1076-827c-45ea-816a-d63242421b22", "AQAAAAEAACcQAAAAEPJDroa0QULmBwKTEuPnonagH8/of/E9uyWtNdF+DUaSoL0gdzIABK8PU3s5jZHniw==", "6c243ade-e69d-436d-b06f-ae4e282940fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4e0d71e3-7aca-4afa-b41c-ad99c9fb5ca7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2624110f-8012-46a8-9692-dc34ecf5493f", "AQAAAAEAACcQAAAAECr17rz0115cHMxCdft/GPFn50nq+c2SnREgvyG5AmPGscLK+DemmtsRG/1L3Qgytg==", "c30d2c5b-e8a9-4138-a82e-7c0a97d16b50" });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "Service" },
                values: new object[,]
                {
                    { "6fe8755b-080a-40e0-9347-ace110fcef60", "Web Development" },
                    { "743e7821-5b25-450c-99f7-3c7bbb3e60c7", "Carpenter" },
                    { "b9e3dba2-7d9a-4af8-8f64-0be6b4a868df", "Graphic Designing" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicesAvailable_serviceTypeId",
                table: "ServicesAvailable",
                column: "serviceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicesAvailable");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94d5a42a-076a-440d-b57c-d2fca8896085",
                column: "ConcurrencyStamp",
                value: "21264ce5-ef95-4e97-9520-fee6ab212e10");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db45eba7-bfea-4bb7-a6a8-45ae1a59e9a0",
                column: "ConcurrencyStamp",
                value: "864813d0-40aa-4924-8e47-1284156ebb44");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4d913ae6-b161-446d-9759-2145d277c1d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8468dfe4-200d-4392-97a6-0102a1c7b208", "AQAAAAEAACcQAAAAEE0a3+Vu3mm2Pn7M4Rro0k7nSQi8MFnJZ62LK7gnpDCUbnFq92RvmQXTItwzJewnBQ==", "079d5028-ce6b-4858-a00a-7da515d82c4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4e0d71e3-7aca-4afa-b41c-ad99c9fb5ca7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d599b786-d72e-42df-ab5a-eec707216497", "AQAAAAEAACcQAAAAEHm1jRWp0tDijJRyQr0bgirdqH/zLxET9oj2ctTNiBTak1qD0G5lCDgcIehik8fRVQ==", "4dc8c3b2-a5a6-49c2-b3f2-a5121c0196c4" });
        }
    }
}
