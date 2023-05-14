using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesOrder.Api.Migrations
{
    /// <inheritdoc />
    public partial class OrderMasterChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderMasters_stateInfo_StateId",
                table: "orderMasters");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "orderMasters",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "orderMasters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "orderMasters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "orderMasters",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "orderMasters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "stateInfo",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 14, 23, 1, 28, 913, DateTimeKind.Local).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "stateInfo",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 14, 23, 1, 28, 913, DateTimeKind.Local).AddTicks(5823));

            migrationBuilder.AddForeignKey(
                name: "FK_orderMasters_stateInfo_StateId",
                table: "orderMasters",
                column: "StateId",
                principalTable: "stateInfo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderMasters_stateInfo_StateId",
                table: "orderMasters");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "orderMasters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "orderMasters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "orderMasters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "orderMasters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "orderMasters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "stateInfo",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 9, 2, 45, 22, 385, DateTimeKind.Local).AddTicks(6498));

            migrationBuilder.UpdateData(
                table: "stateInfo",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 9, 2, 45, 22, 385, DateTimeKind.Local).AddTicks(6529));

            migrationBuilder.AddForeignKey(
                name: "FK_orderMasters_stateInfo_StateId",
                table: "orderMasters",
                column: "StateId",
                principalTable: "stateInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
