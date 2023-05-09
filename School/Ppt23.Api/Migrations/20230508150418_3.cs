using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ppt23.Api.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "BoughtDate", "LastRevisionDate", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("9ab77602-8aac-40ed-b042-d2d4b4e04b31"), new DateTime(2016, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Microscope", 679104 },
                    { new Guid("cd93f294-e926-4f04-bf3e-d06091f82ccc"), new DateTime(2010, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2012, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Injection", 78323 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("9ab77602-8aac-40ed-b042-d2d4b4e04b31"));

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("cd93f294-e926-4f04-bf3e-d06091f82ccc"));
        }
    }
}
