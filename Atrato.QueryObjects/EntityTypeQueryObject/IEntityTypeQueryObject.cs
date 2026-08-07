using Atrato.Entities.DTO.EntityType;

namespace Atrato.QueryObjects.EntityTypeQueryObject;

public interface IEntityTypeQueryObject
{
    IEntityTypeQueryObject Clear();
    IEntityTypeQueryObject ForId(Guid id);
    Task<List<EntityTypeQueryData>> GetAll(CancellationToken cancellationToken);
    Task<EntityTypeQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}
