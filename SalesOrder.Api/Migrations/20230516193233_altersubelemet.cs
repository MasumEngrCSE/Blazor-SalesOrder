using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesOrder.Api.Migrations
{
    /// <inheritdoc />
    public partial class altersubelemet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderWindowsSubElements_subElements_SubElementId",
                table: "orderWindowsSubElements");

            migrationBuilder.DropIndex(
                name: "IX_orderWindowsSubElements_SubElementId",
                table: "orderWindowsSubElements");

            migrationBuilder.RenameColumn(
                name: "SubElementId",
                table: "orderWindowsSubElements",
                newName: "SubElement");

            migrationBuilder.AddColumn<string>(
                name: "SubElementType",
                table: "orderWindowsSubElements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "stateInfo",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 17, 1, 32, 33, 215, DateTimeKind.Local).AddTicks(5107));

            migrationBuilder.UpdateData(
                table: "stateInfo",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 17, 1, 32, 33, 215, DateTimeKind.Local).AddTicks(5138));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubElementType",
                table: "orderWindowsSubElements");

            migrationBuilder.RenameColumn(
                name: "SubElement",
                table: "orderWindowsSubElements",
                newName: "SubElementId");

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

            migrationBuilder.CreateIndex(
                name: "IX_orderWindowsSubElements_SubElementId",
                table: "orderWindowsSubElements",
                column: "SubElementId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderWindowsSubElements_subElements_SubElementId",
                table: "orderWindowsSubElements",
                column: "SubElementId",
                principalTable: "subElements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
