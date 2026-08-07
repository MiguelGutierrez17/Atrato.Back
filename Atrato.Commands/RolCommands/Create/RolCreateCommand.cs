using Atrato.Commands.RolAuditCommands.Create;
using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Rol;
using Atrato.Entities.Extensions;
using Atrato.Entities.SupportDTO;

namespace Atrato.Commands.RolCommands.Create;

public class RolCreateCommand : IRolCreateCommand
{
    private readonly AtratoContext _context;
    private readonly IRolAuditCreateCommand _auditCreateCommand;

    public RolCreateCommand(AtratoContext context, IRolAuditCreateCommand auditCreateCommand)
    {
        _context = context;
        _auditCreateCommand = auditCreateCommand;
    }

    public async Task<RolQueryData> Execute(RolCreateRequest request, Guid userId)
    {
        Rol doc = new()
        {
            Description = request.Description,
            EnterpriseId = request.EnterpriseId,
            Name = request.Name,
            State = request.State,
        };

        _context.Add(doc);
        await _context.SaveChangesAsync();

        await _auditCreateCommand.Execute(doc.CastToAuditRequest(AuditAction.Create, userId));

        return new RolQueryData()
        {
            Id = doc.Id,
            Description = doc.Description,
            EnterpriseId = doc.EnterpriseId,
            Name = doc.Name,
            State = doc.State,
        };
    }
}