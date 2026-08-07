using Atrato.Commands.WorkStationAuditCommands.Create;
using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.WorkStation;
using Atrato.Entities.Extensions;
using Atrato.Entities.SupportDTO;

namespace Atrato.Commands.WorkStationCommands.Create;

public class WorkStationCreateCommand : IWorkStationCreateCommand
{
    private readonly AtratoContext _context;
    private readonly IWorkStationAuditCreateCommand _auditCreateCommand;

    public WorkStationCreateCommand(AtratoContext context, IWorkStationAuditCreateCommand auditCreateCommand)
    {
        _context = context;
        _auditCreateCommand = auditCreateCommand;
    }

    public async Task<WorkStationQueryData> Execute(WorkStationCreateRequest request, Guid userId)
    {
        WorkStation doc = new()
        {
            Name = request.Name,
            OwnerArea = request.OwnerArea,
            PositionX = request.PositionX,
            PositionY = request.PositionY,
            WorkplaceId = request.WorkplaceId,
            WorkStationStateId = request.WorkStationStateId,
        };

        _context.Add(doc);
        await _context.SaveChangesAsync();

        await _auditCreateCommand.Execute(doc.CastToAuditRequest(AuditAction.Create, userId));

        return new WorkStationQueryData()
        {
            Id = doc.Id,
            Name = doc.Name,
            OwnerArea = doc.OwnerArea,
            PositionX = doc.PositionX,
            PositionY = doc.PositionY,
            WorkplaceId = doc.WorkplaceId,
            WorkStationStateId = doc.WorkStationStateId,
        };
    }
}