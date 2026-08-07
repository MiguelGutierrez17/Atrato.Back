using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Ticket;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.TicketQueryObject;

public class TicketQueryObject : ITicketQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<Ticket> _query;

    public TicketQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.Ticket.AsQueryable();
    }

    public ITicketQueryObject Clear()
    {
        _query = _context.Ticket.AsQueryable();
        return this;
    }

    public ITicketQueryObject ForId(Guid id)
    {
        _query = from t in _query
            where t.Id == id
            select t;

        return this;
    }

    public ITicketQueryObject ForWorkStation(Guid workStationId)
    {
        _query = from t in _query
            where t.WorkStationId == workStationId
            select t;

        return this;
    }

    public ITicketQueryObject ForUser(Guid userId)
    {
        _query = from t in _query
            where t.UserId == userId
            select t;

        return this;
    }

    public ITicketQueryObject ForTicketState(Guid ticketStateId)
    {
        _query = from t in _query
            where t.TicketStateId == ticketStateId
            select t;

        return this;
    }

    public ITicketQueryObject ForEnterprise(Guid enterpriseId)
    {
        _query = from t in _query
            join ws in _context.WorkStation on t.WorkStationId equals ws.Id
            join wp in _context.Workplace on ws.WorkplaceId equals wp.Id
            where wp.EnterpriseId == enterpriseId
            select t;

        return this;
    }

    public async Task<List<TicketQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from t in _query.AsNoTracking()
            join ws in _context.WorkStation on t.WorkStationId equals ws.Id
            join ts in _context.TicketState on t.TicketStateId equals ts.Id
            join u in _context.User on t.UserId equals u.Id
            select new TicketQueryData
            {
                Id = t.Id,
                WorkStationId = t.WorkStationId,
                WorkStation = ws.Name,
                Title = t.Title,
                Body = t.Body,
                UserId = t.UserId,
                User = u.Name + " " + u.LastName,
                Date = t.Date,
                TicketStateId = t.TicketStateId,
                TicketState = ts.Name
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<TicketQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from t in _query.AsNoTracking()
            join ws in _context.WorkStation on t.WorkStationId equals ws.Id
            join ts in _context.TicketState on t.TicketStateId equals ts.Id
            join u in _context.User on t.UserId equals u.Id
            select new TicketQueryData
            {
                Id = t.Id,
                WorkStationId = t.WorkStationId,
                WorkStation = ws.Name,
                Title = t.Title,
                Body = t.Body,
                UserId = t.UserId,
                User = u.Name + " " + u.LastName,
                Date = t.Date,
                TicketStateId = t.TicketStateId,
                TicketState = ts.Name
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}
