using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesOrder.Api.Migrations
{
    /// <inheritdoc />
    public partial class changewindowtable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WindowId",
                table: "orderWindows");

            migrationBuilder.UpdateData(
                table: "stateInfo",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 16, 2, 8, 2, 973, DateTimeKind.Local).AddTicks(7283));

            migrationBuilder.UpdateData(
                table: "stateInfo",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 16, 2, 8, 2, 973, DateTimeKind.Local).AddTicks(7362));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WindowId",
                table: "orderWindows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "stateInfo",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 16, 2, 5, 28, 551, DateTimeKind.Local).AddTicks(2636));

            migrationBuilder.UpdateData(
                table: "stateInfo",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 16, 2, 5, 28, 551, DateTimeKind.Local).AddTicks(2671));
        }
    }
}
