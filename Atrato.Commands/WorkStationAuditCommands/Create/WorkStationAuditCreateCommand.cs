using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.WorkStationAudit;

namespace Atrato.Commands.WorkStationAuditCommands.Create;

public class WorkStationAuditCreateCommand : IWorkStationAuditCreateCommand
{
    private readonly AtratoAuditContext _auditContext;

    public WorkStationAuditCreateCommand(AtratoAuditContext auditContext)
    {
        _auditContext = auditContext;
    }

    public Task Execute(WorkStationAuditCreateRequest request)
    {
        WorkStationAudit doc = new()
        {
            AuditAction = request.AuditAction,
            DateChange = request.DateChange,
            ItemId = request.ItemId,
            Name = request.Name,
            OwnerArea = request.OwnerArea,
            PositionX = request.PositionX,
            PositionY = request.PositionY,
            UserChange = request.UserChange,
            WorkplaceId = request.WorkplaceId,
            WorkStationStateId = request.WorkStationStateId,
        };

        _auditContext.Add(doc);

        return Task.CompletedTask;
    }
}