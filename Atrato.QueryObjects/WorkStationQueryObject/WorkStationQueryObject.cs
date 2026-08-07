using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.WorkStation;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.WorkStationQueryObject;

public class WorkStationQueryObject : IWorkStationQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<WorkStation> _query;

    public WorkStationQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.WorkStation.AsQueryable();
    }

    public IWorkStationQueryObject Clear()
    {
        _query = _context.WorkStation.AsQueryable();
        return this;
    }

    public IWorkStationQueryObject ForId(Guid id)
    {
        _query = from ws in _query
            where ws.Id == id
            select ws;

        return this;
    }

    public IWorkStationQueryObject ForWorkplace(Guid workplaceId)
    {
        _query = from ws in _query
            where ws.WorkplaceId == workplaceId
            select ws;

        return this;
    }

    public IWorkStationQueryObject ForWorkStationState(Guid workStationStateId)
    {
        _query = from ws in _query
            where ws.WorkStationStateId == workStationStateId
            select ws;

        return this;
    }

    public IWorkStationQueryObject ForOwnerArea(Guid ownerArea)
    {
        _query = from ws in _query
            where ws.OwnerArea == ownerArea
            select ws;

        return this;
    }

    public IWorkStationQueryObject ForEnterprise(Guid enterpriseId)
    {
        _query = from ws in _query
            join wp in _context.Workplace on ws.WorkplaceId equals wp.Id
            where wp.EnterpriseId == enterpriseId
            select ws;

        return this;
    }

    public async Task<List<WorkStationQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from ws in _query.AsNoTracking()
            join wp in _context.Workplace on ws.WorkplaceId equals wp.Id
            join wss in _context.WorkStationState on ws.WorkStationStateId equals wss.Id
            join a in _context.Area on ws.OwnerArea equals a.Id
            select new WorkStationQueryData
            {
                Id = ws.Id,
                Name = ws.Name,
                WorkplaceId = ws.WorkplaceId,
                Workplace = wp.Name,
                WorkStationStateId = ws.WorkStationStateId,
                WorkStationState = wss.Name,
                OwnerArea = ws.OwnerArea,
                OwnerAreaLabel = a.Name,
                PositionX = ws.PositionX,
                PositionY = ws.PositionY
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<WorkStationQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from ws in _query.AsNoTracking()
            join wp in _context.Workplace on ws.WorkplaceId equals wp.Id
            join wss in _context.WorkStationState on ws.WorkStationStateId equals wss.Id
            join a in _context.Area on ws.OwnerArea equals a.Id
            select new WorkStationQueryData
            {
                Id = ws.Id,
                Name = ws.Name,
                WorkplaceId = ws.WorkplaceId,
                Workplace = wp.Name,
                WorkStationStateId = ws.WorkStationStateId,
                WorkStationState = wss.Name,
                OwnerArea = ws.OwnerArea,
                OwnerAreaLabel = a.Name,
                PositionX = ws.PositionX,
                PositionY = ws.PositionY
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}
