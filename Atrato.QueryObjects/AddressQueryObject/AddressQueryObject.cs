using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Address;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.AddressQueryObject;

public class AddressQueryObject : IAddressQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<Address> _query;

    public AddressQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.Address.AsQueryable();
    }

    public IAddressQueryObject Clear()
    {
        _query = _context.Address.AsQueryable();
        return this;
    }

    public IAddressQueryObject ForId(Guid id)
    {
        _query = from a in _query
            where a.Id == id
            select a;

        return this;
    }

    public IAddressQueryObject ForState(bool state)
    {
        _query = from a in _query
            where a.State == state
            select a;

        return this;
    }

    public IAddressQueryObject ForEnterprise(Guid enterpriseId)
    {
        _query = from a in _query
            where a.EnterpriseId == enterpriseId
            select a;

        return this;
    }

    public async Task<List<AddressQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from a in _query.AsNoTracking()
            join e in _context.Enterprise on a.EnterpriseId equals e.Id
            select new AddressQueryData
            {
                Id = a.Id,
                Route = a.Route,
                Latitude = a.Latitude,
                Longitude = a.Longitude,
                ValidationRadiusMeters = a.ValidationRadiusMeters,
                State = a.State,
                EnterpriseId = a.EnterpriseId,
                Enterprise = e.Name
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<AddressQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from a in _query.AsNoTracking()
            join e in _context.Enterprise on a.EnterpriseId equals e.Id
            select new AddressQueryData
            {
                Id = a.Id,
                Route = a.Route,
                Latitude = a.Latitude,
                Longitude = a.Longitude,
                ValidationRadiusMeters = a.ValidationRadiusMeters,
                State = a.State,
                EnterpriseId = a.EnterpriseId,
                Enterprise = e.Name
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}