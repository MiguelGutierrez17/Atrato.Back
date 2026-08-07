using Atrato.Entities.DTO.WorkStationState;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.WorkStationStateService;

public interface IWorkStationStateService
{
    Task<StandardResult<List<WorkStationStateQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<WorkStationStateQueryData?>> ById(Guid id, CancellationToken cancellationToken);
}
