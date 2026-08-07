using Atrato.Entities.DTO.Area;

namespace Atrato.QueryObjects.AreaQueryObject;

public interface IAreaQueryObject
{
    IAreaQueryObject Clear();
    IAreaQueryObject ForId(Guid id);
    IAreaQueryObject ForState(bool state);
    IAreaQueryObject ForEnterprise(Guid enterpriseId);
    Task<List<AreaQueryData>> GetAll(CancellationToken cancellationToken);
    Task<AreaQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}
