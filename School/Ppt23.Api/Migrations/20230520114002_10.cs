using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ppt23.Api.Migrations
{
    /// <inheritdoc />
    public partial class _10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: new Guid("c406ddc7-c8c6-4370-a663-e28827863b78"));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Actions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkerID",
                table: "Actions",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    JobTitle = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actions_WorkerID",
                table: "Actions",
                column: "WorkerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Workers_WorkerID",
                table: "Actions",
                column: "WorkerID",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Workers_WorkerID",
                table: "Actions");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Actions_WorkerID",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "WorkerID",
                table: "Actions");

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "DateTime", "Description", "EquipmentID", "Name" },
                values: new object[] { new Guid("c406ddc7-c8c6-4370-a663-e28827863b78"), new DateTime(2023, 5, 20, 9, 27, 52, 318, DateTimeKind.Local).AddTicks(8509), "Injection was performed", new Guid("cd93f294-e926-4f04-bf3e-d06091f82ccc"), "Injection Action" });
        }
    }
}
