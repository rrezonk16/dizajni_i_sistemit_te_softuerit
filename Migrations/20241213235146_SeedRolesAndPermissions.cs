using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dizajni_i_sistemit_softuerik.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesAndPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "PermissionName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2344), "READ_USERS" },
                    { 2, new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2347), "EDIT_USERS" },
                    { 3, new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2348), "DELETE_USERS" },
                    { 4, new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2350), "CREATE_USERS" },
                    { 5, new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2351), "READ_PRODUCTS" },
                    { 6, new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2353), "EDIT_PRODUCTS" },
                    { 7, new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2354), "DELETE_PRODUCTS" },
                    { 8, new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2356), "CREATE_PRODUCTS" },
                    { 9, new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2357), "READ_ORDERS" },
                    { 10, new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2359), "EDIT_ORDERS" },
                    { 11, new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2360), "DELETE_ORDERS" },
                    { 12, new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2361), "CREATE_ORDERS" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2213), "Admin" },
                    { 2, new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2262), "Delivery" },
                    { 3, new DateTime(2024, 12, 14, 0, 51, 45, 940, DateTimeKind.Local).AddTicks(2264), "Guest" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 12, 1 },
                    { 5, 2 },
                    { 6, 2 },
                    { 9, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
