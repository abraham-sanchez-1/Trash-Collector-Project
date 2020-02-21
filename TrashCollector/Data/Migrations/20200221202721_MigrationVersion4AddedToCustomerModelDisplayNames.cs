using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class MigrationVersion4AddedToCustomerModelDisplayNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c059871-cf4b-42fa-a782-3b692f33d85f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4da0029-dbe4-4905-a0b3-920c111c86b5");

            migrationBuilder.AddColumn<DateTime>(
                name: "OneTimePickUp",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bacf2e92-4525-42d8-b882-1166c27caab4", "ef222cd9-918c-4b81-92c1-4374d41de789", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b8906438-a2be-4971-8a64-f1ad2c624f53", "bb2cc357-d7f8-43f3-904a-0dff56c6a53b", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8906438-a2be-4971-8a64-f1ad2c624f53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bacf2e92-4525-42d8-b882-1166c27caab4");

            migrationBuilder.DropColumn(
                name: "OneTimePickUp",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3c059871-cf4b-42fa-a782-3b692f33d85f", "25fcb2b7-2d5b-4fa3-a855-9a6e72701a3a", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4da0029-dbe4-4905-a0b3-920c111c86b5", "c79b4c9a-c6cf-4ccb-aaa1-a750b2c5d44e", "Employee", "EMPLOYEE" });
        }
    }
}
