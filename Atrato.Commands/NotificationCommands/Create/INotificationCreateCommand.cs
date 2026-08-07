using Atrato.Entities.DTO.Notification;

namespace Atrato.Commands.NotificationCommands.Create;

public interface INotificationCreateCommand
{
    Task<NotificationQueryData> Execute(NotificationCreateRequest request, Guid userId);
}