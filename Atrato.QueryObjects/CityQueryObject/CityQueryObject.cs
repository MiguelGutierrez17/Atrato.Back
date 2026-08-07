using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.City;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.CityQueryObject;

public class CityQueryObject : ICityQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<City> _query;

    public CityQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.City.AsQueryable();
    }

    public ICityQueryObject Clear()
    {
        _query = _context.City.AsQueryable();
        return this;
    }

    public ICityQueryObject ForId(Guid id)
    {
        _query = from c in _query
            where c.Id == id
            select c;

        return this;
    }

    public ICityQueryObject ForCountry(Guid countryId)
    {
        _query = from c in _query
            where c.CountryId == countryId
            select c;

        return this;
    }

    public async Task<List<CityQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from c in _query.AsNoTracking()
            join co in _context.Country on c.CountryId equals co.Id
            select new CityQueryData
            {
                Id = c.Id,
                Name = c.Name,
                CountryId = c.CountryId,
                Country = co.Name
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<CityQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from c in _query.AsNoTracking()
            join co in _context.Country on c.CountryId equals co.Id
            select new CityQueryData
            {
                Id = c.Id,
                Name = c.Name,
                CountryId = c.CountryId,
                Country = co.Name
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}
