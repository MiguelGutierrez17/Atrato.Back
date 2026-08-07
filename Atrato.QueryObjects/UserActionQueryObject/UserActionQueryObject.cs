using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.UserAction;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.UserActionQueryObject;

public class UserActionQueryObject : IUserActionQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<UserAction> _query;

    public UserActionQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.UserAction.AsQueryable();
    }

    public IUserActionQueryObject Clear()
    {
        _query = _context.UserAction.AsQueryable();
        return this;
    }

    public IUserActionQueryObject ForId(Guid id)
    {
        _query = from ua in _query
            where ua.Id == id
            select ua;

        return this;
    }

    public async Task<List<UserActionQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from ua in _query.AsNoTracking()
            select new UserActionQueryData
            {
                Id = ua.Id,
                Name = ua.Name
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<UserActionQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from ua in _query.AsNoTracking()
            select new UserActionQueryData
            {
                Id = ua.Id,
                Name = ua.Name
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}
