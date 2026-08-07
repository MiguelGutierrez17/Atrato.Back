using Atrato.Commands.RolAuditCommands.Create;
using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Rol;
using Atrato.Entities.Extensions;
using Atrato.Entities.SupportDTO;

namespace Atrato.Commands.RolCommands.Update;

public class RolUpdateCommand : IRolUpdateCommand
{
    private readonly AtratoContext _context;
    private readonly IRolAuditCreateCommand _auditCreateCommand;

    public RolUpdateCommand(AtratoContext context, IRolAuditCreateCommand auditCreateCommand)
    {
        _context = context;
        _auditCreateCommand = auditCreateCommand;
    }

    public async Task<RolQueryData> Execute(RolUpdateRequest request, Guid userId)
    {
        Rol doc = new()
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