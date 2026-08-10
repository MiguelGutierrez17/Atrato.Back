using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.RolAudit;

namespace Atrato.Commands.RolAuditCommands.Create;

public class RolAuditCreateCommand : IRolAuditCreateCommand
{
    private readonly AtratoAuditContext _auditContext;

    public RolAuditCreateCommand(AtratoAuditContext auditContext)
    {
        _auditContext = auditContext;
    }

    public Task Execute(RolAuditCreateRequest request)
    {
        RolAudit doc = new()
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

        return Task.CompletedTask;
    }
}