using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace adilapi.Migrations
{
    /// <inheritdoc />
    public partial class passwordHashR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "password123");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "password456");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "hashedpassword123");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "hashedpassword456");

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "MobileNumber", "Name", "Password" },
                values: new object[] { 3, "789 Oak Avenue", null, null, null });
        }
    }
}
