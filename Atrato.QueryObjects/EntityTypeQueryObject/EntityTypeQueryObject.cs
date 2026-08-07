using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.EntityType;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.EntityTypeQueryObject;

public class EntityTypeQueryObject : IEntityTypeQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<EntityType> _query;

    public EntityTypeQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.EntityType.AsQueryable();
    }

    public IEntityTypeQueryObject Clear()
    {
        _query = _context.EntityType.AsQueryable();
        return this;
    }

    public IEntityTypeQueryObject ForId(Guid id)
    {
        _query = from et in _query
            where et.Id == id
            select et;

        return this;
    }

    public async Task<List<EntityTypeQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from et in _query.AsNoTracking()
            select new EntityTypeQueryData
            {
                Id = et.Id,
                Name = et.Name
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<EntityTypeQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from et in _query.AsNoTracking()
            select new EntityTypeQueryData
            {
                Id = et.Id,
                Name = et.Name
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}
