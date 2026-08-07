using Atrato.Entities.DTO.WorkplaceAudit;

namespace Atrato.Commands.WorkplaceAuditCommands.Create;

public interface IWorkplaceAuditCreateCommand
{
    Task Execute(WorkplaceAuditCreateRequest request);
}