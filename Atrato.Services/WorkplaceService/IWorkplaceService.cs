using Atrato.Entities.DTO.Workplace;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.WorkplaceService;

public interface IWorkplaceService
{
    Task<StandardResult<List<WorkplaceQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<WorkplaceQueryData?>> ById(Guid id, CancellationToken cancellationToken);
    Task<StandardResult<List<WorkplaceQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken);
    Task<StandardResult<WorkplaceQueryData>> Post(WorkplaceCreateRequest request, Guid userId);
    Task<StandardResult<WorkplaceQueryData>> Put(WorkplaceUpdateRequest request, Guid userId);
}