using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Rol;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.RolQueryObject;

public class RolQueryObject : IRolQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<Rol> _query;

    public RolQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.Rol.AsQueryable();
    }

    public IRolQueryObject Clear()
    {
        _query = _context.Rol.AsQueryable();
        return this;
    }

    public IRolQueryObject ForId(Guid id)
    {
        _query = from r in _query
            where r.Id == id
            select r;

        return this;
    }

    public IRolQueryObject ForState(bool state)
    {
        _query = from r in _query
            where r.State == state
            select r;

        return this;
    }

    public IRolQueryObject ForEnterprise(Guid enterpriseId)
    {
        _query = from r in _query
            where r.EnterpriseId == enterpriseId
            select r;

        return this;
    }

    public async Task<List<RolQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from r in _query.AsNoTracking()
            join e in _context.Enterprise on r.EnterpriseId equals e.Id
            select new RolQueryData
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                State = r.State,
                EnterpriseId = r.EnterpriseId,
                Enterprise = e.Name
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<RolQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from r in _query.AsNoTracking()
            join e in _context.Enterprise on r.EnterpriseId equals e.Id
            select new RolQueryData
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                State = r.State,
                EnterpriseId = r.EnterpriseId,
                Enterprise = e.Name
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}