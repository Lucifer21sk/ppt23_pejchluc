using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ppt23.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: new Guid("c406ddc7-c8c6-4370-a663-e28827863b78"),
                column: "DateTime",
                value: new DateTime(2023, 5, 20, 9, 27, 52, 318, DateTimeKind.Local).AddTicks(8509));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: new Guid("c406ddc7-c8c6-4370-a663-e28827863b78"),
                column: "DateTime",
                value: new DateTime(2023, 5, 20, 9, 22, 36, 534, DateTimeKind.Local).AddTicks(3008));
        }
    }
}
