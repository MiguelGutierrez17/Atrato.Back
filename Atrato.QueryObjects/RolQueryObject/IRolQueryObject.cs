using Atrato.Entities.DTO.Rol;

namespace Atrato.QueryObjects.RolQueryObject;

public interface IRolQueryObject
{
    IRolQueryObject Clear();
    IRolQueryObject ForId(Guid id);
    IRolQueryObject ForState(bool state);
    IRolQueryObject ForEnterprise(Guid enterpriseId);
    Task<List<RolQueryData>> GetAll(CancellationToken cancellationToken);
    Task<RolQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}