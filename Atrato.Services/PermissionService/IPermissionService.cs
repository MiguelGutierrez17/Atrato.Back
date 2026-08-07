using Atrato.Entities.DTO.Permission;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.PermissionService;

public interface IPermissionService
{
    Task<StandardResult<List<PermissionQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<PermissionQueryData?>> ById(Guid id, CancellationToken cancellationToken);
    Task<StandardResult<PermissionQueryData>> Post(PermissionCreateRequest request, Guid userId);
    Task<StandardResult<PermissionQueryData>> Put(PermissionUpdateRequest request, Guid userId);
}
