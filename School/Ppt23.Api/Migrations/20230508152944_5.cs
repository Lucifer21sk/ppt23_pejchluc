using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ppt23.Api.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastRevisionDate",
                table: "Equipment");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Revisions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "EquipmentId",
                table: "Revisions",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Revisions_EquipmentId",
                table: "Revisions",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Revisions_Equipment_EquipmentId",
                table: "Revisions",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revisions_Equipment_EquipmentId",
                table: "Revisions");

            migrationBuilder.DropIndex(
                name: "IX_Revisions_EquipmentId",
                table: "Revisions");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Revisions");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Revisions");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastRevisionDate",
                table: "Equipment",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("9ab77602-8aac-40ed-b042-d2d4b4e04b31"),
                column: "LastRevisionDate",
                value: new DateTime(2015, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("cd93f294-e926-4f04-bf3e-d06091f82ccc"),
                column: "LastRevisionDate",
                value: new DateTime(2012, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
