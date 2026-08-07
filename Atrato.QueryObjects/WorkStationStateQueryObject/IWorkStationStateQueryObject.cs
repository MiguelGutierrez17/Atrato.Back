using Atrato.Entities.DTO.WorkStationState;

namespace Atrato.QueryObjects.WorkStationStateQueryObject;

public interface IWorkStationStateQueryObject
{
    IWorkStationStateQueryObject Clear();
    IWorkStationStateQueryObject ForId(Guid id);
    Task<List<WorkStationStateQueryData>> GetAll(CancellationToken cancellationToken);
    Task<WorkStationStateQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}
