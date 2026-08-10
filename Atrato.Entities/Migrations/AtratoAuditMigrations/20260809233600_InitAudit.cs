using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrato.Entities.Migrations.AtratoAuditMigrations
{
    /// <inheritdoc />
    public partial class InitAudit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Route = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<int>(type: "int", nullable: false),
                    Longitude = table.Column<int>(type: "int", nullable: false),
                    ValidationRadiusMeters = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    EnterpriseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserChange = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditAction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressAudit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreaAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    EnterpriseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserChange = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditAction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaAudit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnterpriseAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeZoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShiftStart = table.Column<int>(type: "int", nullable: false),
                    ShiftEnd = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserChange = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditAction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriseAudit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileDbAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpload = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserChange = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditAction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDbAudit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnterpriseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserChange = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditAction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsAudit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntityTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Receipter = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailSender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailReceipter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isEmail = table.Column<bool>(type: "bit", nullable: false),
                    Read = table.Column<bool>(type: "bit", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    EnterpriseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserChange = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditAction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationAudit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservationAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkStationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CancelByExpireTime = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdempotencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserChange = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditAction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationAudit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    EnterpriseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserChange = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditAction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolAudit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkStationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserChange = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditAction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketAudit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Initials = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    isSuperAdmin = table.Column<bool>(type: "bit", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserChange = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditAction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAudit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkplaceAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaitTime = table.Column<int>(type: "int", nullable: true),
                    EnterpriseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserChange = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditAction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkplaceAudit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkStationAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkplaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkStationStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerArea = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionX = table.Column<int>(type: "int", nullable: false),
                    PositionY = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserChange = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditAction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkStationAudit", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressAudit");

            migrationBuilder.DropTable(
                name: "AreaAudit");

            migrationBuilder.DropTable(
                name: "EnterpriseAudit");

            migrationBuilder.DropTable(
                name: "FileDbAudit");

            migrationBuilder.DropTable(
                name: "NewsAudit");

            migrationBuilder.DropTable(
                name: "NotificationAudit");

            migrationBuilder.DropTable(
                name: "ReservationAudit");

            migrationBuilder.DropTable(
                name: "RolAudit");

            migrationBuilder.DropTable(
                name: "TicketAudit");

            migrationBuilder.DropTable(
                name: "UserAudit");

            migrationBuilder.DropTable(
                name: "WorkplaceAudit");

            migrationBuilder.DropTable(
                name: "WorkStationAudit");
        }
    }
}
