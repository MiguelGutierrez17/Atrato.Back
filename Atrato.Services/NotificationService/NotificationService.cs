using Atrato.Commands.NotificationCommands.Create;
using Atrato.Commands.NotificationCommands.Update;
using Atrato.Entities.DTO.Notification;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.NotificationQueryObject;

namespace Atrato.Services.NotificationService;

public class NotificationService : INotificationService
{
    private readonly INotificationCreateCommand _createCommand;
    private readonly INotificationUpdateCommand _updateCommand;
    private readonly INotificationQueryObject _queryObject;

    public NotificationService(
        INotificationCreateCommand createCommand,
        INotificationUpdateCommand updateCommand,
        INotificationQueryObject queryObject)
    {
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<NotificationQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.GetAll(cancellationToken);

        return new StandardResult<List<NotificationQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<NotificationQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<NotificationQueryData?>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<List<NotificationQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForEnterprise(enterpriseId).GetAll(cancellationToken);

        return new StandardResult<List<NotificationQueryData>>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<List<NotificationQueryData>>> ByUser(Guid userId, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForUser(userId).GetAll(cancellationToken);

        return new StandardResult<List<NotificationQueryData>>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<List<NotificationQueryData>>> ByUserEnterprise(Guid userId, Guid enterpriseId, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForUser(userId).ForEnterprise(enterpriseId).GetAll(cancellationToken);

        return new StandardResult<List<NotificationQueryData>>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<NotificationQueryData>> Post(NotificationCreateRequest request, Guid userId)
    {
        var response = await _createCommand.Execute(request, userId);

        return new StandardResult<NotificationQueryData>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<NotificationQueryData>> Put(NotificationUpdateRequest request, Guid userId)
    {
        var response = await _updateCommand.Execute(request, userId);

        return new StandardResult<NotificationQueryData>()
        {
            Success = true,
            Data = response
        };
    }
}
