using Atrato.Entities.DTO.Permission;

namespace Atrato.QueryObjects.PermissionQueryObject;

public interface IPermissionQueryObject
{
    IPermissionQueryObject Clear();
    IPermissionQueryObject ForId(Guid id);
    IPermissionQueryObject ForState(bool state);
    Task<List<PermissionQueryData>> GetAll(CancellationToken cancellationToken);
    Task<PermissionQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}
