using Atrato.Entities.DTO.Rol;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.RolService;

public interface IRolService
{
    Task<StandardResult<List<RolQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<RolQueryData?>> ById(Guid id, CancellationToken cancellationToken);
    Task<StandardResult<List<RolQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken);
    Task<StandardResult<RolQueryData>> Post(RolCreateRequest request, Guid userId);
    Task<StandardResult<RolQueryData>> Put(RolUpdateRequest request, Guid userId);
}