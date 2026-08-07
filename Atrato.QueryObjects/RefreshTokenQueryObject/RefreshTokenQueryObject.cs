using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.RefreshToken;
using Microsoft.EntityFrameworkCore;

namespace Atrato.QueryObjects.RefreshTokenQueryObject;

public class RefreshTokenQueryObject : IRefreshTokenQueryObject
{
    private readonly AtratoContext _context;
    private IQueryable<RefreshToken> _query;

    public RefreshTokenQueryObject(AtratoContext context)
    {
        _context = context;
        _query = _context.RefreshToken.AsQueryable();
    }

    public IRefreshTokenQueryObject Clear()
    {
        _query = _context.RefreshToken.AsQueryable();
        return this;
    }

    public IRefreshTokenQueryObject ForId(Guid id)
    {
        _query = from rt in _query
            where rt.Id == id
            select rt;

        return this;
    }

    public IRefreshTokenQueryObject ForUser(Guid userId)
    {
        _query = from rt in _query
            where rt.UserId == userId
            select rt;

        return this;
    }

    public IRefreshTokenQueryObject ForExpired(bool state)
    {
        _query = from rt in _query
            where rt.isExpired == state
            select rt;

        return this;
    }

    public IRefreshTokenQueryObject ForToken(string token)
    {
        _query = from rt in _query
            where rt.Token == token
            select rt;

        return this;
    }

    public async Task<List<RefreshTokenQueryData>> GetAll(CancellationToken cancellationToken)
    {
        var response =
            from rt in _query.AsNoTracking()
            join u in _context.User on rt.UserId equals u.Id
            select new RefreshTokenQueryData
            {
                Id = rt.Id,
                Token = rt.Token,
                CreationDate = rt.CreationDate,
                ExpirationDate = rt.ExpirationDate,
                isExpired = rt.isExpired,
                ExpiredAt = rt.ExpiredAt,
                UserId = rt.UserId,
                User = u.Name + " " + u.LastName
            };

        return await response.ToListAsync(cancellationToken);
    }

    public async Task<RefreshTokenQueryData?> FirstOrDefault(CancellationToken cancellationToken)
    {
        var response =
            from rt in _query.AsNoTracking()
            join u in _context.User on rt.UserId equals u.Id
            select new RefreshTokenQueryData
            {
                Id = rt.Id,
                Token = rt.Token,
                CreationDate = rt.CreationDate,
                ExpirationDate = rt.ExpirationDate,
                isExpired = rt.isExpired,
                ExpiredAt = rt.ExpiredAt,
                UserId = rt.UserId,
                User = u.Name + " " + u.LastName
            };

        return await response.FirstOrDefaultAsync(cancellationToken);
    }
}