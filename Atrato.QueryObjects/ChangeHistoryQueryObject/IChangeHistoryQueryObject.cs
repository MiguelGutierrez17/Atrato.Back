using Atrato.Entities.DTO.ChangeHistory;

namespace Atrato.QueryObjects.ChangeHistoryQueryObject;

public interface IChangeHistoryQueryObject
{
    IChangeHistoryQueryObject Clear();
    IChangeHistoryQueryObject ForId(Guid id);
    IChangeHistoryQueryObject ForEnterprise(Guid enterpriseId);
    IChangeHistoryQueryObject ForEntityType(Guid entityTypeId);
    IChangeHistoryQueryObject ForUserAction(Guid userActionId);
    IChangeHistoryQueryObject ForActionUser(Guid actionUser);
    IChangeHistoryQueryObject ForItem(Guid itemId);
    Task<List<ChangeHistoryQueryData>> GetAll(CancellationToken cancellationToken);
    Task<ChangeHistoryQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}
