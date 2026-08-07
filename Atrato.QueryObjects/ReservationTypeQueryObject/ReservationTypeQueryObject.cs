using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.ReservationType;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.ReservationTypeQueryObject;

public class ReservationTypeQueryObject : IReservationTypeQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<ReservationType> _query;

    public ReservationTypeQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.ReservationType.AsQueryable();
    }

    public IReservationTypeQueryObject Clear()
    {
        _query = _context.ReservationType.AsQueryable();
        return this;
    }

    public IReservationTypeQueryObject ForId(Guid id)
    {
        _query = from rt in _query
            where rt.Id == id
            select rt;

        return this;
    }

    public async Task<List<ReservationTypeQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from rt in _query.AsNoTracking()
            select new ReservationTypeQueryData
            {
                Id = rt.Id,
                Name = rt.Name
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<ReservationTypeQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from rt in _query.AsNoTracking()
            select new ReservationTypeQueryData
            {
                Id = rt.Id,
                Name = rt.Name
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}
