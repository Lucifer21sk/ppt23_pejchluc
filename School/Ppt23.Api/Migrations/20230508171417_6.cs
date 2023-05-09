using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ppt23.Api.Migrations
{
    /// <inheritdoc />
    public partial class _6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Revisions",
                columns: new[] { "Id", "DateTime", "EquipmentId", "Name" },
                values: new object[,]
                {
                    { new Guid("1465be46-5dbf-4c9f-b397-df4c91176eb9"), new DateTime(2019, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9ab77602-8aac-40ed-b042-d2d4b4e04b31"), "First" },
                    { new Guid("adb6a0a6-80b6-4637-8008-2e7ce2fc7e8e"), new DateTime(2020, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cd93f294-e926-4f04-bf3e-d06091f82ccc"), "Second" },
                    { new Guid("b106ddc7-c8c6-4370-a663-e28827862a78"), new DateTime(2019, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cd93f294-e926-4f04-bf3e-d06091f82ccc"), "First" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Revisions",
                keyColumn: "Id",
                keyValue: new Guid("1465be46-5dbf-4c9f-b397-df4c91176eb9"));

            migrationBuilder.DeleteData(
                table: "Revisions",
                keyColumn: "Id",
                keyValue: new Guid("adb6a0a6-80b6-4637-8008-2e7ce2fc7e8e"));

            migrationBuilder.DeleteData(
                table: "Revisions",
                keyColumn: "Id",
                keyValue: new Guid("b106ddc7-c8c6-4370-a663-e28827862a78"));
        }
    }
}
