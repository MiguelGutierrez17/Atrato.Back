using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Permission;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.PermissionQueryObject;

public class PermissionQueryObject : IPermissionQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<Permission> _query;

    public PermissionQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.Permission.AsQueryable();
    }

    public IPermissionQueryObject Clear()
    {
        _query = _context.Permission.AsQueryable();
        return this;
    }

    public IPermissionQueryObject ForId(Guid id)
    {
        _query = from p in _query
            where p.Id == id
            select p;

        return this;
    }

    public IPermissionQueryObject ForState(bool state)
    {
        _query = from p in _query
            where p.State == state
            select p;

        return this;
    }

    public async Task<List<PermissionQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from p in _query.AsNoTracking()
            select new PermissionQueryData
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                State = p.State
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<PermissionQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from p in _query.AsNoTracking()
            select new PermissionQueryData
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                State = p.State
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}
