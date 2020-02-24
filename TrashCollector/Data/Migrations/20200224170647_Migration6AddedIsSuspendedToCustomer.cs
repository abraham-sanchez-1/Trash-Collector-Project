using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class Migration6AddedIsSuspendedToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d71f6de-258a-4d46-ad85-5e4d85e9b21b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f26ebc35-b092-4b4a-9fee-49d9681a5d50");

            migrationBuilder.AddColumn<bool>(
                name: "IsSuspended",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "234fc3ad-603f-4472-93b9-465d3546852b", "c628b16a-d57f-461f-bd7c-6a6434b461ee", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2cb57da1-8c5d-48e3-ac88-a26c06aea9c5", "71272b26-c255-4eb0-bc89-e0bacb1f87b4", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "234fc3ad-603f-4472-93b9-465d3546852b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cb57da1-8c5d-48e3-ac88-a26c06aea9c5");

            migrationBuilder.DropColumn(
                name: "IsSuspended",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f26ebc35-b092-4b4a-9fee-49d9681a5d50", "1b282758-88a8-4084-b512-9fc7e9b5a3c6", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d71f6de-258a-4d46-ad85-5e4d85e9b21b", "ebdcd1ad-f4b5-465d-b089-185d91dde548", "Employee", "EMPLOYEE" });
        }
    }
}
