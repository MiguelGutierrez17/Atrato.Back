using Atrato.Entities.DTO.Notification;

namespace Atrato.Commands.NotificationCommands.Update;

public interface INotificationUpdateCommand
{
    Task<NotificationQueryData> Execute(NotificationUpdateRequest request, Guid userId);
}