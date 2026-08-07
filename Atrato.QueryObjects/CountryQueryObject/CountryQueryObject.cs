using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Country;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.CountryQueryObject;

public class CountryQueryObject : ICountryQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<Country> _query;

    public CountryQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.Country.AsQueryable();
    }

    public ICountryQueryObject Clear()
    {
        _query = _context.Country.AsQueryable();
        return this;
    }

    public ICountryQueryObject ForId(Guid id)
    {
        _query = from c in _query
            where c.Id == id
            select c;

        return this;
    }

    public async Task<List<CountryQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from c in _query.AsNoTracking()
            select new CountryQueryData
            {
                Id = c.Id,
                Name = c.Name
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<CountryQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from c in _query.AsNoTracking()
            select new CountryQueryData
            {
                Id = c.Id,
                Name = c.Name
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}
