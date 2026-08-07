using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.WorkStationState;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.WorkStationStateQueryObject;

public class WorkStationStateQueryObject : IWorkStationStateQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<WorkStationState> _query;

    public WorkStationStateQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.WorkStationState.AsQueryable();
    }

    public IWorkStationStateQueryObject Clear()
    {
        _query = _context.WorkStationState.AsQueryable();
        return this;
    }

    public IWorkStationStateQueryObject ForId(Guid id)
    {
        _query = from wss in _query
            where wss.Id == id
            select wss;

        return this;
    }

    public async Task<List<WorkStationStateQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from wss in _query.AsNoTracking()
            select new WorkStationStateQueryData
            {
                Id = wss.Id,
                Name = wss.Name
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<WorkStationStateQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from wss in _query.AsNoTracking()
            select new WorkStationStateQueryData
            {
                Id = wss.Id,
                Name = wss.Name
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}
