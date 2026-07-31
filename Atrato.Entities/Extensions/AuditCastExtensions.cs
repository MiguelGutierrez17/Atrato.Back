using Atrato.Entities.Documents;
using Atrato.Entities.DTO.EnterpriseAudit;
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
}