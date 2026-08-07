using Atrato.Entities.DTO.EntityType;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.EntityTypeService;

public interface IEntityTypeService
{
    Task<StandardResult<List<EntityTypeQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<EntityTypeQueryData?>> ById(Guid id, CancellationToken cancellationToken);
}
