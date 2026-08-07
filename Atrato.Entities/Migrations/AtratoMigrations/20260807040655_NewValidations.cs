using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrato.Entities.Migrations.AtratoMigrations
{
    /// <inheritdoc />
    public partial class NewValidations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredAt",
                table: "RefreshToken",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Invitation",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Invitation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Invitation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumberAttempts",
                table: "Invitation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UsedAt",
                table: "Invitation",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Invitation");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Invitation");

            migrationBuilder.DropColumn(
                name: "NumberAttempts",
                table: "Invitation");

            migrationBuilder.DropColumn(
                name: "UsedAt",
                table: "Invitation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredAt",
                table: "RefreshToken",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "Invitation",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);
        }
    }
}
