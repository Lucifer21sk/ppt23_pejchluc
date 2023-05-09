using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ppt23.Api.Migrations
{
    /// <inheritdoc />
    public partial class _7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "BoughtDate", "Name", "Price" },
                values: new object[] { new Guid("0a7959e7-d736-414f-8834-c73c00e12afb"), new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "X-Ray", 452610 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("0a7959e7-d736-414f-8834-c73c00e12afb"));
        }
    }
}
