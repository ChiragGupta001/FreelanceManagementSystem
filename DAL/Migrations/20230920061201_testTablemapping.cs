using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class testTablemapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94d5a42a-076a-440d-b57c-d2fca8896085",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "8df8db4a-ef41-4489-a70c-beee69cde141", "SERVICEPROVIDER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db45eba7-bfea-4bb7-a6a8-45ae1a59e9a0",
                column: "ConcurrencyStamp",
                value: "d4327840-3fd5-4bbc-9d16-14acef8b8c77");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4d913ae6-b161-446d-9759-2145d277c1d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e477fefa-fc2b-4f99-80d3-a0da54a5c93c", "AQAAAAEAACcQAAAAEByleNLDAuUDhe4PXJjgtC1QXGA7h2JoOnbNwQTtJW8yv4GMRGf/BxUs+4a/+K7+lA==", "2e691277-500a-4e89-8d32-5bfed543cace" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4e0d71e3-7aca-4afa-b41c-ad99c9fb5ca7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43608f97-ba14-46fe-83ed-3ffe41eabae4", "AQAAAAEAACcQAAAAEOTx46EErRGp2gACeKH7Y7TOwvNifP11ihver7vTXAAnH4DC/MVIFGVXJm5v7lXrYQ==", "bd8ff26c-0300-415a-ba5d-522d1c0f0341" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94d5a42a-076a-440d-b57c-d2fca8896085",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "64162e2e-65f4-4019-bbbc-f64c748c225c", "ServiceProvider" });

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
        }
    }
}
