using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class Migration5AddedLastPickedUpDayVariable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8906438-a2be-4971-8a64-f1ad2c624f53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bacf2e92-4525-42d8-b882-1166c27caab4");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPickedUp",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f26ebc35-b092-4b4a-9fee-49d9681a5d50", "1b282758-88a8-4084-b512-9fc7e9b5a3c6", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d71f6de-258a-4d46-ad85-5e4d85e9b21b", "ebdcd1ad-f4b5-465d-b089-185d91dde548", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d71f6de-258a-4d46-ad85-5e4d85e9b21b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f26ebc35-b092-4b4a-9fee-49d9681a5d50");

            migrationBuilder.DropColumn(
                name: "LastPickedUp",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bacf2e92-4525-42d8-b882-1166c27caab4", "ef222cd9-918c-4b81-92c1-4374d41de789", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b8906438-a2be-4971-8a64-f1ad2c624f53", "bb2cc357-d7f8-43f3-904a-0dff56c6a53b", "Employee", "EMPLOYEE" });
        }
    }
}
