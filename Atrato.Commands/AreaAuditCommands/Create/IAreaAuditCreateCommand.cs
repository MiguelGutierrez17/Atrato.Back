using Atrato.Entities.DTO.AreaAudit;

namespace Atrato.Commands.AreaAuditCommands.Create;

public interface IAreaAuditCreateCommand
{
    Task Execute(AreaAuditCreateRequest request);
}
