using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.AreaAudit;

namespace Atrato.Commands.AreaAuditCommands.Create;

public class AreaAuditCreateCommand : IAreaAuditCreateCommand
{
    private readonly AtratoAuditContext _auditContext;

    public AreaAuditCreateCommand(AtratoAuditContext auditContext)
    {
        _auditContext = auditContext;
    }

    public async Task Execute(AreaAuditCreateRequest request)
    {
        AreaAudit doc = new()
        {
            AuditAction = request.AuditAction,
            DateChange = request.DateChange,
            Description = request.Description,
            EnterpriseId = request.EnterpriseId,
            ItemId = request.ItemId,
            Name = request.Name,
            State = request.State,
            UserChange = request.UserChange,
        };

        _auditContext.Add(doc);
        await _auditContext.SaveChangesAsync();
    }
}
