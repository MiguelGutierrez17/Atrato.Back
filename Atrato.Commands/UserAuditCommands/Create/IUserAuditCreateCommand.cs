using Atrato.Entities.DTO.UserAudit;

namespace Atrato.Commands.UserAuditCommands.Create;

public interface IUserAuditCreateCommand
{
    Task Execute(UserAuditCreateRequest request);
}