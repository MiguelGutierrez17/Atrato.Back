using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrato.Entities.Migrations.AtratoMigrations
{
    /// <inheritdoc />
    public partial class TimeZoneTypeError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enterprise_TimeZone_TimeZoneId",
                table: "Enterprise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeZone",
                table: "TimeZone");

            migrationBuilder.RenameTable(
                name: "TimeZone",
                newName: "TimeZoneData");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TimeZoneData",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeZoneData",
                table: "TimeZoneData",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enterprise_TimeZoneData_TimeZoneId",
                table: "Enterprise",
                column: "TimeZoneId",
                principalTable: "TimeZoneData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enterprise_TimeZoneData_TimeZoneId",
                table: "Enterprise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeZoneData",
                table: "TimeZoneData");

            migrationBuilder.RenameTable(
                name: "TimeZoneData",
                newName: "TimeZone");

            migrationBuilder.AlterColumn<Guid>(
                name: "Description",
                table: "TimeZone",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeZone",
                table: "TimeZone",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enterprise_TimeZone_TimeZoneId",
                table: "Enterprise",
                column: "TimeZoneId",
                principalTable: "TimeZone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
