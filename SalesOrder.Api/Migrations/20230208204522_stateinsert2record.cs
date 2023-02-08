using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesOrder.Api.Migrations
{
    /// <inheritdoc />
    public partial class stateinsert2record : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "stateInfo",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 2, 9, 2, 45, 22, 385, DateTimeKind.Local).AddTicks(6498), "New York", "NY", null, null },
                    { 2, null, new DateTime(2023, 2, 9, 2, 45, 22, 385, DateTimeKind.Local).AddTicks(6529), "California", "CA", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "stateInfo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "stateInfo",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
