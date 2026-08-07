using Atrato.Entities.DTO.NewsAudit;

namespace Atrato.Commands.NewsAuditCommands.Create;

public interface INewsAuditCreateCommand
{
    Task Execute(NewsAuditCreateRequest request);
}