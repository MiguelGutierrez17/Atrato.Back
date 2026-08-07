using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.User;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.UserQueryObject;

public class UserQueryObject : IUserQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<User> _query;

    public UserQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.User.AsQueryable();
    }

    public IUserQueryObject Clear()
    {
        _query = _context.User.AsQueryable();
        return this;
    }

    public IUserQueryObject ForId(Guid id)
    {
        _query = from u in _query
            where u.Id == id
            select u;

        return this;
    }

    public IUserQueryObject ForEmail(string email)
    {
        _query = from u in _query
            where u.Email == email
            select u;

        return this;
    }

    public IUserQueryObject ForState(bool state)
    {
        _query = from u in _query
            where u.State == state
            select u;

        return this;
    }

    public IUserQueryObject ForEnterprise(Guid enterpriseId)
    {
        _query = from u in _query
            join ue in _context.UserEnterprise on u.Id equals ue.UserId
            where ue.EnterpriseId == enterpriseId
            select u;

        return this;
    }

    public async Task<List<UserQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from u in _query.AsNoTracking()
            select new UserQueryData
            {
                Id = u.Id,
                Name = u.Name,
                LastName = u.LastName,
                Initials = u.Initials,
                Email = u.Email,
                Phone = u.Phone,
                State = u.State,
                isSuperAdmin = u.isSuperAdmin
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<UserQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from u in _query.AsNoTracking()
            select new UserQueryData
            {
                Id = u.Id,
                Name = u.Name,
                LastName = u.LastName,
                Initials = u.Initials,
                Email = u.Email,
                Phone = u.Phone,
                State = u.State,
                isSuperAdmin = u.isSuperAdmin
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}