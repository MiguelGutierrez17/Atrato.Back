using Atrato.Entities.DTO.Notification;

namespace Atrato.QueryObjects.NotificationQueryObject;

public interface INotificationQueryObject
{
    INotificationQueryObject Clear();
    INotificationQueryObject ForId(Guid id);
    INotificationQueryObject ForState(bool state);
    INotificationQueryObject ForEnterprise(Guid enterpriseId);
    INotificationQueryObject ForUser(Guid userId);
    INotificationQueryObject ForEntityType(Guid entityTypeId);
    Task<List<NotificationQueryData>> GetAll(CancellationToken cancellationToken);
    Task<NotificationQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}
