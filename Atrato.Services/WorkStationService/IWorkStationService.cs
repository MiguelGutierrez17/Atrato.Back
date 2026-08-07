using Atrato.Entities.DTO.WorkStation;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.WorkStationService;

public interface IWorkStationService
{
    Task<StandardResult<List<WorkStationQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<WorkStationQueryData?>> ById(Guid id, CancellationToken cancellationToken);
    Task<StandardResult<List<WorkStationQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken);
    Task<StandardResult<List<WorkStationQueryData>>> ByWorkplace(Guid workplaceId, CancellationToken cancellationToken);
    Task<StandardResult<WorkStationQueryData>> Post(WorkStationCreateRequest request, Guid userId);
    Task<StandardResult<WorkStationQueryData>> Put(WorkStationUpdateRequest request, Guid userId);
}
