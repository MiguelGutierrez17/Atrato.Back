using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrato.Entities.Migrations.AtratoMigrations
{
    /// <inheritdoc />
    public partial class AllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "FileId",
                table: "News",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_News_FileId",
                table: "News",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeHistory_ActionUser",
                table: "ChangeHistory",
                column: "ActionUser");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeHistory_User_ActionUser",
                table: "ChangeHistory",
                column: "ActionUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_FileDb_FileId",
                table: "News",
                column: "FileId",
                principalTable: "FileDb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_WorkStation_WorkStationId",
                table: "Reservation",
                column: "WorkStationId",
                principalTable: "WorkStation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeHistory_User_ActionUser",
                table: "ChangeHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_News_FileDb_FileId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_WorkStation_WorkStationId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_News_FileId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_ChangeHistory_ActionUser",
                table: "ChangeHistory");

            migrationBuilder.AlterColumn<Guid>(
                name: "FileId",
                table: "News",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
