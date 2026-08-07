using Atrato.Entities.DTO.EntityType;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.EntityTypeQueryObject;

namespace Atrato.Services.EntityTypeService;

public class EntityTypeService : IEntityTypeService
{
    private readonly IEntityTypeQueryObject _queryObject;

    public EntityTypeService(IEntityTypeQueryObject queryObject)
    {
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<EntityTypeQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.GetAll(cancellationToken);

        return new StandardResult<List<EntityTypeQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<EntityTypeQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<EntityTypeQueryData?>()
        {
            Success = true,
            Data = response
        };
    }
}
