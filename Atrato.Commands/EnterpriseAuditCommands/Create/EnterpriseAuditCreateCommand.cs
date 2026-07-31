using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.EnterpriseAudit;

namespace Atrato.Commands.EnterpriseAuditCommands.Create;

public class EnterpriseAuditCreateCommand : IEnterpriseAuditCreateCommand
{
    private readonly AtratoAuditContext _auditContext;

    public EnterpriseAuditCreateCommand(AtratoAuditContext auditContext)
    {
        _auditContext = auditContext;
    }

    public async Task Execute(EnterpriseAuditCreateRequest request)
    {
        EnterpriseAudit doc = new()
        {
            AuditAction = request.AuditAction,
            CityId = request.CityId,
            DateChange = request.DateChange,
            Email = request.Email,
            Identification = request.Identification,
            Name = request.Name,
            ItemId = request.ItemId,
            Picture = request.Picture,
            ShiftEnd = request.ShiftEnd,
            ShiftStart = request.ShiftStart,
            State = request.State,
            TimeZoneId = request.TimeZoneId,
            UserChange = request.UserChange,
            Phone = request.Phone,
        };

        _auditContext.Add(doc);
        await _auditContext.SaveChangesAsync();
    }
}