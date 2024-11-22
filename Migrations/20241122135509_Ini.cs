using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace adilapi.Migrations
{
    /// <inheritdoc />
    public partial class Ini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName" },
                values: new object[] { 5, "789s Pine Lane", "alices.johnson@example.com", "Aliced", "Johnsoon" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
