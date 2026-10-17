using Atrato.Entities.Documents;
using Atrato.Entities.DTO.User;

namespace Atrato.QueryObjects.UserQueryObject;

public interface IUserQueryObject
{
    IUserQueryObject Clear();
    IUserQueryObject ForId(Guid id);
    IUserQueryObject ForEmail(string email);
    IUserQueryObject ForState(bool state);
    IUserQueryObject ForEnterprise(Guid enterpriseId);
    IQueryable<User> Query();
    Task<List<UserQueryData>> GetAll(CancellationToken cancellationToken);
    Task<UserQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}