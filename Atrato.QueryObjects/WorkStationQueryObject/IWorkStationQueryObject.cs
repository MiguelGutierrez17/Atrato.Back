using Atrato.Entities.DTO.WorkStation;

namespace Atrato.QueryObjects.WorkStationQueryObject;

public interface IWorkStationQueryObject
{
    IWorkStationQueryObject Clear();
    IWorkStationQueryObject ForId(Guid id);
    IWorkStationQueryObject ForWorkplace(Guid workplaceId);
    IWorkStationQueryObject ForWorkStationState(Guid workStationStateId);
    IWorkStationQueryObject ForOwnerArea(Guid ownerArea);
    IWorkStationQueryObject ForEnterprise(Guid enterpriseId);
    Task<List<WorkStationQueryData>> GetAll(CancellationToken cancellationToken);
    Task<WorkStationQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}
