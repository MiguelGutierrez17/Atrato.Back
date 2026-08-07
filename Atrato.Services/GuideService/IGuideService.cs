using Atrato.Entities.DTO.Guide;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.GuideService;

public interface IGuideService
{
    Task<StandardResult<List<GuideQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<GuideQueryData?>> ById(Guid id, CancellationToken cancellationToken);
    Task<StandardResult<List<GuideQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken);
}
