using Atrato.Entities.DTO.ChangeHistory;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.ChangeHistoryService;

public interface IChangeHistoryService
{
    Task<StandardResult<List<ChangeHistoryQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<ChangeHistoryQueryData?>> ById(Guid id, CancellationToken cancellationToken);
    Task<StandardResult<List<ChangeHistoryQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken);
    Task<StandardResult<ChangeHistoryQueryData>> Post(ChangeHistoryCreateRequest request, Guid userId);
    Task<StandardResult<ChangeHistoryQueryData>> Put(ChangeHistoryUpdateRequest request, Guid userId);
}
