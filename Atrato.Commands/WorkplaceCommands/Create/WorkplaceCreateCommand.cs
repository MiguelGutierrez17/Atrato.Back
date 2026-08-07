using Atrato.Commands.WorkplaceAuditCommands.Create;
using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Workplace;
using Atrato.Entities.Extensions;
using Atrato.Entities.SupportDTO;

namespace Atrato.Commands.WorkplaceCommands.Create;

public class WorkplaceCreateCommand : IWorkplaceCreateCommand
{
    private readonly AtratoContext _context;
    private readonly IWorkplaceAuditCreateCommand _auditCreateCommand;

    public WorkplaceCreateCommand(AtratoContext context, IWorkplaceAuditCreateCommand auditCreateCommand)
    {
        _context = context;
        _auditCreateCommand = auditCreateCommand;
    }

    public async Task<WorkplaceQueryData> Execute(WorkplaceCreateRequest request, Guid userId)
    {
        Workplace doc = new()
        {
            EnterpriseId = request.EnterpriseId,
            Image = request.Image,
            Name = request.Name,
            State = request.State,
            WaitTime = request.WaitTime,
        };

        _context.Add(doc);
        await _context.SaveChangesAsync();

        await _auditCreateCommand.Execute(doc.CastToAuditRequest(AuditAction.Create, userId));

        return new WorkplaceQueryData()
        {
            Id = doc.Id,
            EnterpriseId = doc.EnterpriseId,
            Image = doc.Image,
            Name = doc.Name,
            State = doc.State,
            WaitTime = doc.WaitTime,
        };
    }
}