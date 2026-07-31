using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Enterprise;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.EnterpriseQueryObject;

public class EnterpriseQueryObject : IEnterpriseQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<Enterprise> _query;

    public EnterpriseQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.Enterprise.AsQueryable();
    }

    public IEnterpriseQueryObject Clear()
    {
        _query = _context.Enterprise.AsQueryable();
        return this;
    }

    public IEnterpriseQueryObject ForId(Guid id)
    {
        _query = from e in _query
            where e.Id == id
            select e;

        return this;
    }

    public IEnterpriseQueryObject ForUser(Guid userId)
    {
        _query = from e in _query
            join ue in _context.UserEnterprise on e.Id equals ue.EnterpriseId
            where ue.UserId == userId
            select e;

        return this;
    }

    public async Task<List<EnterpriseQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from e in _query.AsNoTracking()
            join c in _context.City on e.CityId equals c.Id
            join tz in _context.TimeZoneData on e.TimeZoneId equals tz.Id
            select new EnterpriseQueryData
            {
                Id = e.Id,
                Name = e.Name,
                Phone = e.Phone,
                Email = e.Email,
                CityId = e.CityId,
                Identification = e.Identification,
                State = e.State,
                TimeZoneId = e.TimeZoneId,
                Picture = e.Picture,
                ShiftEnd = e.ShiftEnd,
                ShiftStart = e.ShiftStart,
                City = c.Name,
                TimeZone = tz.Description
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<EnterpriseQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from e in _query.AsNoTracking()
            join c in _context.City on e.CityId equals c.Id
            join tz in _context.TimeZoneData on e.TimeZoneId equals tz.Id
            select new EnterpriseQueryData
            {
                Id = e.Id,
                Name = e.Name,
                Phone = e.Phone,
                Email = e.Email,
                CityId = e.CityId,
                Identification = e.Identification,
                State = e.State,
                TimeZoneId = e.TimeZoneId,
                Picture = e.Picture,
                ShiftEnd = e.ShiftEnd,
                ShiftStart = e.ShiftStart,
                City = c.Name,
                TimeZone = tz.Description
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}