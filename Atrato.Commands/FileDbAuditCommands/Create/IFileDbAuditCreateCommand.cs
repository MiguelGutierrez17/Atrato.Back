using Atrato.Entities.DTO.FileDbAudit;

namespace Atrato.Commands.FileDbAuditCommands.Create;

public interface IFileDbAuditCreateCommand
{
    Task Execute(FileDbAuditCreateRequest request);
}