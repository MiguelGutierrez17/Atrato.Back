using Atrato.Entities.DTO.Notification;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.NotificationService;

public interface INotificationService
{
    Task<StandardResult<List<NotificationQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<NotificationQueryData?>> ById(Guid id, CancellationToken cancellationToken);
    Task<StandardResult<List<NotificationQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken);
    Task<StandardResult<List<NotificationQueryData>>> ByUser(Guid userId, CancellationToken cancellationToken);
    Task<StandardResult<List<NotificationQueryData>>> ByUserEnterprise(Guid userId, Guid enterpriseId, CancellationToken cancellationToken);
    Task<StandardResult<NotificationQueryData>> Post(NotificationCreateRequest request, Guid userId);
    Task<StandardResult<NotificationQueryData>> Put(NotificationUpdateRequest request, Guid userId);
}
