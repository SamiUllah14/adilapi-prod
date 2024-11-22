using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace adilapi.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Persons",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "Persons",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Persons",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MobileNumber", "Name" },
                values: new object[] { "1234567890", "Sami Doe" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "MobileNumber", "Name" },
                values: new object[] { "456 Elm Street", "9876543210", "Kaleem Smith" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "MobileNumber", "Name" },
                values: new object[] { "789 Oak Avenue", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Persons",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Persons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Persons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Persons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "john.doe@example.com", "John", "Doe" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Email", "FirstName", "LastName" },
                values: new object[] { "456 Oak Avenue", "jane.smith@example.com", "Jane", "Smith" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "Email", "FirstName", "LastName" },
                values: new object[] { "789 Pine Lane", "alice.johnson@example.com", "Alice", "Johnson" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName" },
                values: new object[] { 5, "789s Pine Lane", "alices.johnson@example.com", "Aliced", "Johnsoon" });
        }
    }
}
