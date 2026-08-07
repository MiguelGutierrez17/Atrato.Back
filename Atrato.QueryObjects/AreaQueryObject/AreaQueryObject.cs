using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Area;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.AreaQueryObject;

public class AreaQueryObject : IAreaQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<Area> _query;

    public AreaQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.Area.AsQueryable();
    }

    public IAreaQueryObject Clear()
    {
        _query = _context.Area.AsQueryable();
        return this;
    }

    public IAreaQueryObject ForId(Guid id)
    {
        _query = from a in _query
            where a.Id == id
            select a;

        return this;
    }

    public IAreaQueryObject ForState(bool state)
    {
        _query = from a in _query
            where a.State == state
            select a;

        return this;
    }

    public IAreaQueryObject ForEnterprise(Guid enterpriseId)
    {
        _query = from a in _query
            where a.EnterpriseId == enterpriseId
            select a;

        return this;
    }

    public async Task<List<AreaQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from a in _query.AsNoTracking()
            join e in _context.Enterprise on a.EnterpriseId equals e.Id
            select new AreaQueryData
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                State = a.State,
                EnterpriseId = a.EnterpriseId,
                Enterprise = e.Name
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<AreaQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from a in _query.AsNoTracking()
            join e in _context.Enterprise on a.EnterpriseId equals e.Id
            select new AreaQueryData
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                State = a.State,
                EnterpriseId = a.EnterpriseId,
                Enterprise = e.Name
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}
