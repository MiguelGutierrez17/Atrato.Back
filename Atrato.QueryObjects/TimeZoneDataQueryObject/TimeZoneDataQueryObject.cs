using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.TimeZoneData;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.TimeZoneDataQueryObject;

public class TimeZoneDataQueryObject : ITimeZoneDataQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<TimeZoneData> _query;

    public TimeZoneDataQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.TimeZoneData.AsQueryable();
    }

    public ITimeZoneDataQueryObject Clear()
    {
        _query = _context.TimeZoneData.AsQueryable();
        return this;
    }

    public ITimeZoneDataQueryObject ForId(Guid id)
    {
        _query = from tz in _query
            where tz.Id == id
            select tz;

        return this;
    }

    public async Task<List<TimeZoneDataQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from tz in _query.AsNoTracking()
            select new TimeZoneDataQueryData
            {
                Id = tz.Id,
                Description = tz.Description,
                MinutesToUtc = tz.MinutesToUtc
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<TimeZoneDataQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from tz in _query.AsNoTracking()
            select new TimeZoneDataQueryData
            {
                Id = tz.Id,
                Description = tz.Description,
                MinutesToUtc = tz.MinutesToUtc
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}
