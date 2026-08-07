using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.ReservationState;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.ReservationStateQueryObject;

public class ReservationStateQueryObject : IReservationStateQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<ReservationState> _query;

    public ReservationStateQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.ReservationState.AsQueryable();
    }

    public IReservationStateQueryObject Clear()
    {
        _query = _context.ReservationState.AsQueryable();
        return this;
    }

    public IReservationStateQueryObject ForId(Guid id)
    {
        _query = from rs in _query
            where rs.Id == id
            select rs;

        return this;
    }

    public async Task<List<ReservationStateQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from rs in _query.AsNoTracking()
            select new ReservationStateQueryData
            {
                Id = rs.Id,
                Name = rs.Name
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<ReservationStateQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from rs in _query.AsNoTracking()
            select new ReservationStateQueryData
            {
                Id = rs.Id,
                Name = rs.Name
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}
