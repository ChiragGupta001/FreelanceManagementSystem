using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddusertoServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "ServicesAvailable",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94d5a42a-076a-440d-b57c-d2fca8896085",
                column: "ConcurrencyStamp",
                value: "64162e2e-65f4-4019-bbbc-f64c748c225c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db45eba7-bfea-4bb7-a6a8-45ae1a59e9a0",
                column: "ConcurrencyStamp",
                value: "47ad3f0e-95c2-4474-954a-5d1a2942b946");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4d913ae6-b161-446d-9759-2145d277c1d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51031b60-b109-461f-bf50-24e33ce16f56", "AQAAAAEAACcQAAAAEJ5FWVuSAecbN0uO1niIlWqrpdCzabaEXcPh7yuOWxVbZGWwwPuHiW2KSrA7uNlfVA==", "ed2b3112-7396-4978-a539-83c9daf843fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4e0d71e3-7aca-4afa-b41c-ad99c9fb5ca7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59ac5c0b-8c90-4441-a3db-7012bc284641", "AQAAAAEAACcQAAAAEHo9WqqxXhV/D8rzdLgdlopbWydILbT8jd9eSUpi/pVVmhxu6xuqILpkJpPaaSfSvQ==", "bb4a0009-01ee-42e2-a3b2-b108a1d8d409" });

            migrationBuilder.CreateIndex(
                name: "IX_ServicesAvailable_userId",
                table: "ServicesAvailable",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesAvailable_AspNetUsers_userId",
                table: "ServicesAvailable",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicesAvailable_AspNetUsers_userId",
                table: "ServicesAvailable");

            migrationBuilder.DropIndex(
                name: "IX_ServicesAvailable_userId",
                table: "ServicesAvailable");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "ServicesAvailable");

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
        }
    }
}
