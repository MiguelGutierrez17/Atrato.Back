using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.WorkplaceAudit;

namespace Atrato.Commands.WorkplaceAuditCommands.Create;

public class WorkplaceAuditCreateCommand : IWorkplaceAuditCreateCommand
{
    private readonly AtratoAuditContext _auditContext;

    public WorkplaceAuditCreateCommand(AtratoAuditContext auditContext)
    {
        _auditContext = auditContext;
    }

    public async Task Execute(WorkplaceAuditCreateRequest request)
    {
        WorkplaceAudit doc = new()
        {
            AuditAction = request.AuditAction,
            DateChange = request.DateChange,
            EnterpriseId = request.EnterpriseId,
            Image = request.Image,
            ItemId = request.ItemId,
            Name = request.Name,
            State = request.State,
            UserChange = request.UserChange,
            WaitTime = request.WaitTime,
        };

        _auditContext.Add(doc);
        await _auditContext.SaveChangesAsync();
    }
}