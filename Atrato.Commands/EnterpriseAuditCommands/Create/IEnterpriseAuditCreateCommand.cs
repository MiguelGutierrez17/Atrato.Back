using Atrato.Entities.DTO.EnterpriseAudit;

namespace Atrato.Commands.EnterpriseAuditCommands.Create;

public interface IEnterpriseAuditCreateCommand
{
    Task Execute(EnterpriseAuditCreateRequest request);
}