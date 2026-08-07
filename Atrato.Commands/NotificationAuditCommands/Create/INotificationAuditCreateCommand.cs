using Atrato.Entities.DTO.NotificationAudit;

namespace Atrato.Commands.NotificationAuditCommands.Create;

public interface INotificationAuditCreateCommand
{
    Task Execute(NotificationAuditCreateRequest request);
}