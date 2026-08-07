using Atrato.Commands.AreaAuditCommands.Create;
using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Area;
using Atrato.Entities.Extensions;
using Atrato.Entities.SupportDTO;

namespace Atrato.Commands.AreaCommands.Update;

public class AreaUpdateCommand : IAreaUpdateCommand
{
    private readonly AtratoContext _context;
    private readonly IAreaAuditCreateCommand _auditCreateCommand;

    public AreaUpdateCommand(AtratoContext context, IAreaAuditCreateCommand auditCreateCommand)
    {
        _context = context;
        _auditCreateCommand = auditCreateCommand;
    }

    public async Task<AreaQueryData> Execute(AreaUpdateRequest request, Guid userId)
    {
        Area doc = new()
        {
            Id = request.Id,
            Description = request.Description,
            EnterpriseId = request.EnterpriseId,
            Name = request.Name,
            State = request.State,
        };

        _context.Update(doc);
        await _context.SaveChangesAsync();

        await _auditCreateCommand.Execute(doc.CastToAuditRequest(AuditAction.Update, userId));

        return new AreaQueryData()
        {
            Id = doc.Id,
            Description = doc.Description,
            EnterpriseId = doc.EnterpriseId,
            Name = doc.Name,
            State = doc.State,
        };
    }
}