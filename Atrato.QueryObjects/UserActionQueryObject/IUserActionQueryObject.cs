using Atrato.Entities.DTO.UserAction;

namespace Atrato.QueryObjects.UserActionQueryObject;

public interface IUserActionQueryObject
{
    IUserActionQueryObject Clear();
    IUserActionQueryObject ForId(Guid id);
    Task<List<UserActionQueryData>> GetAll(CancellationToken cancellationToken);
    Task<UserActionQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}
