using Atrato.Entities.DTO.Workplace;

namespace Atrato.QueryObjects.WorkplaceQueryObject;

public interface IWorkplaceQueryObject
{
    IWorkplaceQueryObject Clear();
    IWorkplaceQueryObject ForId(Guid id);
    IWorkplaceQueryObject ForState(bool state);
    IWorkplaceQueryObject ForEnterprise(Guid enterpriseId);
    Task<List<WorkplaceQueryData>> GetAll(CancellationToken cancellationToken);
    Task<WorkplaceQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}