using Atrato.Entities.DTO.RolAudit;

namespace Atrato.Commands.RolAuditCommands.Create;

public interface IRolAuditCreateCommand
{
    Task Execute(RolAuditCreateRequest request);
}