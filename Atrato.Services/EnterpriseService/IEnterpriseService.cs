using Atrato.Entities.DTO.Enterprise;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.EnterpriseService;

public interface IEnterpriseService
{
    Task<StandardResult<List<EnterpriseQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<EnterpriseQueryData?>> GetById(Guid id, CancellationToken cancellationToken);
    Task<StandardResult<EnterpriseQueryData>> Post(EnterpriseCreateRequest request, Guid userId);
    Task<StandardResult<EnterpriseQueryData>> Put(EnterpriseUpdateRequest request, Guid userId);
}