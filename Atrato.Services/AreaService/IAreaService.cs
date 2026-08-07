using Atrato.Entities.DTO.Area;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.AreaService;

public interface IAreaService
{
    Task<StandardResult<List<AreaQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<AreaQueryData?>> ById(Guid id, CancellationToken cancellationToken);
    Task<StandardResult<List<AreaQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken);
    Task<StandardResult<AreaQueryData>> Post(AreaCreateRequest request, Guid userId);
    Task<StandardResult<AreaQueryData>> Put(AreaUpdateRequest request, Guid userId);
}
