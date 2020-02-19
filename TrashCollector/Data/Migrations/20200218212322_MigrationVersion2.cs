using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class MigrationVersion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5e4ce81-252c-460b-9b5b-9e6eb47fd4b4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "518d90ac-603e-471c-97ff-11ee13bd7d0c", "9bf5b384-ec8e-4fa9-97cb-52e92046b144", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dfc1c969-7785-42a9-ab55-83f51495b7c3", "84d77e9a-47bf-4ad8-ba62-670d864bf84e", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "518d90ac-603e-471c-97ff-11ee13bd7d0c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfc1c969-7785-42a9-ab55-83f51495b7c3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a5e4ce81-252c-460b-9b5b-9e6eb47fd4b4", "7c29eb50-dfff-4566-8d3c-2ed03b4754f3", "Admin", "ADMIN" });
        }
    }
}
