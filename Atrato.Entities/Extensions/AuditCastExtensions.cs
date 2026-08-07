using Atrato.Entities.Documents;
using Atrato.Entities.DTO.AddressAudit;
using Atrato.Entities.DTO.AreaAudit;
using Atrato.Entities.DTO.EnterpriseAudit;
using Atrato.Entities.DTO.FileDbAudit;
using Atrato.Entities.DTO.NewsAudit;
using Atrato.Entities.DTO.NotificationAudit;
using Atrato.Entities.DTO.ReservationAudit;
using Atrato.Entities.DTO.RolAudit;
using Atrato.Entities.DTO.TicketAudit;
using Atrato.Entities.DTO.UserAudit;
using Atrato.Entities.DTO.WorkplaceAudit;
using Atrato.Entities.DTO.WorkStationAudit;
using Atrato.Entities.SupportDTO;

namespace Atrato.Entities.Extensions;

public static class AuditCastExtensions
{
    public static EnterpriseAuditCreateRequest CastToAuditRequest(this Enterprise Doc, AuditAction Action, Guid UserId)
    {
        return new EnterpriseAuditCreateRequest()
        {
            AuditAction = (int)Action,
            CityId = Doc.CityId,
            DateChange = DateTime.UtcNow,
            Email = Doc.Email,
            Identification = Doc.Identification,
            Name = Doc.Name,
            Phone = Doc.Phone,
            ItemId = Doc.Id,
            Picture = Doc.Picture,
            ShiftEnd = Doc.ShiftEnd,
            ShiftStart = Doc.ShiftStart,
            State = Doc.State,
            TimeZoneId = Doc.TimeZoneId,
            UserChange = UserId
        };
    }

    public static AreaAuditCreateRequest CastToAuditRequest(this Area Doc, AuditAction Action, Guid UserId)
    {
        return new AreaAuditCreateRequest()
        {
            AuditAction = (int)Action,
            DateChange = DateTime.UtcNow,
            Description = Doc.Description,
            EnterpriseId = Doc.EnterpriseId,
            ItemId = Doc.Id,
            Name = Doc.Name,
            State = Doc.State,
            UserChange = UserId
        };
    }

    public static AddressAuditCreateRequest CastToAuditRequest(this Address Doc, AuditAction Action, Guid UserId)
    {
        return new AddressAuditCreateRequest()
        {
            AuditAction = (int)Action,
            DateChange = DateTime.UtcNow,
            EnterpriseId = Doc.EnterpriseId,
            ItemId = Doc.Id,
            Latitude = Doc.Latitude,
            Longitude = Doc.Longitude,
            Route = Doc.Route,
            State = Doc.State,
            UserChange = UserId,
            ValidationRadiusMeters = Doc.ValidationRadiusMeters
        };
    }

    public static WorkplaceAuditCreateRequest CastToAuditRequest(this Workplace Doc, AuditAction Action, Guid UserId)
    {
        return new WorkplaceAuditCreateRequest()
        {
            AuditAction = (int)Action,
            DateChange = DateTime.UtcNow,
            EnterpriseId = Doc.EnterpriseId,
            Image = Doc.Image,
            ItemId = Doc.Id,
            Name = Doc.Name,
            State = Doc.State,
            UserChange = UserId,
            WaitTime = Doc.WaitTime
        };
    }

    public static NewsAuditCreateRequest CastToAuditRequest(this News Doc, AuditAction Action, Guid UserId)
    {
        return new NewsAuditCreateRequest()
        {
            AuditAction = (int)Action,
            Body = Doc.Body,
            DateChange = DateTime.UtcNow,
            EndDate = Doc.EndDate,
            EnterpriseId = Doc.EnterpriseId,
            FileId = Doc.FileId,
            ItemId = Doc.Id,
            StartDate = Doc.StartDate,
            State = Doc.State,
            Title = Doc.Title,
            UserChange = UserId
        };
    }

    public static RolAuditCreateRequest CastToAuditRequest(this Rol Doc, AuditAction Action, Guid UserId)
    {
        return new RolAuditCreateRequest()
        {
            AuditAction = (int)Action,
            DateChange = DateTime.UtcNow,
            Description = Doc.Description,
            EnterpriseId = Doc.EnterpriseId,
            ItemId = Doc.Id,
            Name = Doc.Name,
            State = Doc.State,
            UserChange = UserId
        };
    }

    public static UserAuditCreateRequest CastToAuditRequest(this User Doc, AuditAction Action, Guid UserId)
    {
        return new UserAuditCreateRequest()
        {
            AuditAction = (int)Action,
            DateChange = DateTime.UtcNow,
            Email = Doc.Email,
            Initials = Doc.Initials,
            isSuperAdmin = Doc.isSuperAdmin,
            ItemId = Doc.Id,
            LastName = Doc.LastName,
            Name = Doc.Name,
            Phone = Doc.Phone,
            State = Doc.State,
            UserChange = UserId
        };
    }

    public static FileDbAuditCreateRequest CastToAuditRequest(this FileDb Doc, AuditAction Action, Guid UserId)
    {
        return new FileDbAuditCreateRequest()
        {
            AuditAction = (int)Action,
            DateChange = DateTime.UtcNow,
            DateUpload = Doc.DateUpload,
            Extension = Doc.Extension,
            ItemId = Doc.Id,
            Name = Doc.Name,
            State = Doc.State,
            StorageId = Doc.StorageId,
            TypeFile = Doc.TypeFile,
            UserChange = UserId,
            UserId = Doc.UserId
        };
    }

    public static NotificationAuditCreateRequest CastToAuditRequest(this Notification Doc, AuditAction Action, Guid UserId)
    {
        return new NotificationAuditCreateRequest()
        {
            AuditAction = (int)Action,
            Date = Doc.Date,
            DateChange = DateTime.UtcNow,
            Description = Doc.Description,
            EmailReceipter = Doc.EmailReceipter,
            EmailSender = Doc.EmailSender,
            EnterpriseId = Doc.EnterpriseId,
            EntityTypeId = Doc.EntityTypeId,
            isEmail = Doc.isEmail,
            ItemId = Doc.Id,
            Read = Doc.Read,
            Receipter = Doc.Receipter,
            State = Doc.State,
            UserChange = UserId
        };
    }

    public static TicketAuditCreateRequest CastToAuditRequest(this Ticket Doc, AuditAction Action, Guid UserId)
    {
        return new TicketAuditCreateRequest()
        {
            AuditAction = (int)Action,
            Body = Doc.Body,
            Date = Doc.Date,
            DateChange = DateTime.UtcNow,
            ItemId = Doc.Id,
            TicketStateId = Doc.TicketStateId,
            Title = Doc.Title,
            UserChange = UserId,
            UserId = Doc.UserId,
            WorkStationId = Doc.WorkStationId
        };
    }

    public static WorkStationAuditCreateRequest CastToAuditRequest(this WorkStation Doc, AuditAction Action, Guid UserId)
    {
        return new WorkStationAuditCreateRequest()
        {
            AuditAction = (int)Action,
            DateChange = DateTime.UtcNow,
            ItemId = Doc.Id,
            Name = Doc.Name,
            OwnerArea = Doc.OwnerArea,
            PositionX = Doc.PositionX,
            PositionY = Doc.PositionY,
            UserChange = UserId,
            WorkplaceId = Doc.WorkplaceId,
            WorkStationStateId = Doc.WorkStationStateId
        };
    }

    public static ReservationAuditCreateRequest CastToAuditRequest(this Reservation Doc, AuditAction Action, Guid UserId)
    {
        return new ReservationAuditCreateRequest()
        {
            AuditAction = (int)Action,
            CancelByExpireTime = Doc.CancelByExpireTime,
            CheckInDate = Doc.CheckInDate,
            CheckOutDate = Doc.CheckOutDate,
            CreatedAt = Doc.CreatedAt,
            DateChange = DateTime.UtcNow,
            EndDate = Doc.EndDate,
            IdempotencyId = Doc.IdempotencyId,
            ItemId = Doc.Id,
            ReservationStateId = Doc.ReservationStateId,
            ReservationTypeId = Doc.ReservationTypeId,
            RowVersion = Doc.RowVersion,
            StartDate = Doc.StartDate,
            UpdatedAt = Doc.UpdatedAt,
            UserChange = UserId,
            UserId = Doc.UserId,
            WorkStationId = Doc.WorkStationId
        };
    }
}