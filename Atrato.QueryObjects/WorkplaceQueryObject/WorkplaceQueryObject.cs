using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Workplace;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.WorkplaceQueryObject;

public class WorkplaceQueryObject : IWorkplaceQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<Workplace> _query;

    public WorkplaceQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.Workplace.AsQueryable();
    }

    public IWorkplaceQueryObject Clear()
    {
        _query = _context.Workplace.AsQueryable();
        return this;
    }

    public IWorkplaceQueryObject ForId(Guid id)
    {
        _query = from w in _query
            where w.Id == id
            select w;

        return this;
    }

    public IWorkplaceQueryObject ForState(bool state)
    {
        _query = from w in _query
            where w.State == state
            select w;

        return this;
    }

    public IWorkplaceQueryObject ForEnterprise(Guid enterpriseId)
    {
        _query = from w in _query
            where w.EnterpriseId == enterpriseId
            select w;

        return this;
    }

    public async Task<List<WorkplaceQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from w in _query.AsNoTracking()
            join e in _context.Enterprise on w.EnterpriseId equals e.Id
            select new WorkplaceQueryData
            {
                Id = w.Id,
                Name = w.Name,
                Image = w.Image,
                WaitTime = w.WaitTime,
                State = w.State,
                EnterpriseId = w.EnterpriseId,
                Enterprise = e.Name
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<WorkplaceQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from w in _query.AsNoTracking()
            join e in _context.Enterprise on w.EnterpriseId equals e.Id
            select new WorkplaceQueryData
            {
                Id = w.Id,
                Name = w.Name,
                Image = w.Image,
                WaitTime = w.WaitTime,
                State = w.State,
                EnterpriseId = w.EnterpriseId,
                Enterprise = e.Name
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}