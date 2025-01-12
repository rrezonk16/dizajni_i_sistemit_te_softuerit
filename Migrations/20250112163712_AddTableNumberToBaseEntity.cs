using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dizajni_i_sistemit_softuerik.Migrations
{
    /// <inheritdoc />
    public partial class AddTableNumberToBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TableNumber",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TableNumber",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TableNumber",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TableNumber",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TableNumber",
                table: "Permissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TableNumber",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TableNumber",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TableNumber",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TableNumber",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TableNumber",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2025, 1, 12, 16, 37, 11, 827, DateTimeKind.Utc).AddTicks(9314), 0 });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2025, 1, 12, 16, 37, 11, 827, DateTimeKind.Utc).AddTicks(9315), 0 });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2025, 1, 12, 16, 37, 11, 827, DateTimeKind.Utc).AddTicks(9316), 0 });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2025, 1, 12, 16, 37, 11, 827, DateTimeKind.Utc).AddTicks(9317), 0 });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2025, 1, 12, 16, 37, 11, 827, DateTimeKind.Utc).AddTicks(9318), 0 });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2025, 1, 12, 16, 37, 11, 827, DateTimeKind.Utc).AddTicks(9319), 0 });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2025, 1, 12, 16, 37, 11, 827, DateTimeKind.Utc).AddTicks(9320), 0 });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2025, 1, 12, 16, 37, 11, 827, DateTimeKind.Utc).AddTicks(9321), 0 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2025, 1, 12, 16, 37, 11, 827, DateTimeKind.Utc).AddTicks(9188), 0 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2025, 1, 12, 16, 37, 11, 827, DateTimeKind.Utc).AddTicks(9190), 0 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2025, 1, 12, 16, 37, 11, 827, DateTimeKind.Utc).AddTicks(9192), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "Clients");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 7, 20, 8, 51, 413, DateTimeKind.Utc).AddTicks(8854));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 7, 20, 8, 51, 413, DateTimeKind.Utc).AddTicks(8856));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 7, 20, 8, 51, 413, DateTimeKind.Utc).AddTicks(8857));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 7, 20, 8, 51, 413, DateTimeKind.Utc).AddTicks(8858));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 7, 20, 8, 51, 413, DateTimeKind.Utc).AddTicks(8859));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 7, 20, 8, 51, 413, DateTimeKind.Utc).AddTicks(8860));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 7, 20, 8, 51, 413, DateTimeKind.Utc).AddTicks(8861));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 7, 20, 8, 51, 413, DateTimeKind.Utc).AddTicks(8862));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 7, 20, 8, 51, 413, DateTimeKind.Utc).AddTicks(8750));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 7, 20, 8, 51, 413, DateTimeKind.Utc).AddTicks(8752));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 7, 20, 8, 51, 413, DateTimeKind.Utc).AddTicks(8753));
        }
    }
}
