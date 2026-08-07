using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.TicketState;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.TicketStateQueryObject;

public class TicketStateQueryObject : ITicketStateQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<TicketState> _query;

    public TicketStateQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.TicketState.AsQueryable();
    }

    public ITicketStateQueryObject Clear()
    {
        _query = _context.TicketState.AsQueryable();
        return this;
    }

    public ITicketStateQueryObject ForId(Guid id)
    {
        _query = from ts in _query
            where ts.Id == id
            select ts;

        return this;
    }

    public async Task<List<TicketStateQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from ts in _query.AsNoTracking()
            select new TicketStateQueryData
            {
                Id = ts.Id,
                Name = ts.Name
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<TicketStateQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from ts in _query.AsNoTracking()
            select new TicketStateQueryData
            {
                Id = ts.Id,
                Name = ts.Name
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}
