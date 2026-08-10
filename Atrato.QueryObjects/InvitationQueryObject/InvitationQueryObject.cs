using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Invitation;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.InvitationQueryObject;

public class InvitationQueryObject : IInvitationQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<Invitation> _query;

    public InvitationQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.Invitation.AsQueryable();
    }

    public IInvitationQueryObject Clear()
    {
        _query = _context.Invitation.AsQueryable();
        return this;
    }

    public IInvitationQueryObject ForId(Guid id)
    {
        _query = from i in _query
            where i.Id == id
            select i;

        return this;
    }

    public IInvitationQueryObject ForState(bool state)
    {
        _query = from i in _query
            where i.State == state
            select i;

        return this;
    }

    public IInvitationQueryObject ForUser(Guid userId)
    {
        _query = from i in _query
            where i.UserId == userId
            select i;

        return this;
    }

    public IInvitationQueryObject ForUserEmail(string email)
    {
        _query = from i in _query
            join u in _context.User on i.UserId equals u.Id
            where u.Email == email
            select i;

        return this;
    }

    public IInvitationQueryObject ForCode(string code)
    {
        _query = from i in _query
            where i.Code == code
            select i;

        return this;
    }

    public async Task<List<InvitationQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from i in _query.AsNoTracking()
            join u in _context.User on i.UserId equals u.Id
            select new InvitationQueryData
            {
                Id = i.Id,
                UserId = i.UserId,
                User = u.Name + " " + u.LastName,
                Code = i.Code,
                State = i.State,
                NumberAttempts = i.NumberAttempts,
                CreationDate = i.CreationDate,
                ExpirationDate = i.ExpirationDate,
                UsedAt = i.UsedAt
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<InvitationQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from i in _query.AsNoTracking()
            join u in _context.User on i.UserId equals u.Id
            orderby i.CreationDate descending
            select new InvitationQueryData
            {
                Id = i.Id,
                UserId = i.UserId,
                User = u.Name + " " + u.LastName,
                Code = i.Code,
                State = i.State,
                NumberAttempts = i.NumberAttempts,
                CreationDate = i.CreationDate,
                ExpirationDate = i.ExpirationDate,
                UsedAt = i.UsedAt
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}