using Atrato.Entities.DTO.RefreshToken;

namespace Atrato.QueryObjects.RefreshTokenQueryObject;

public interface IRefreshTokenQueryObject
{
    IRefreshTokenQueryObject Clear();
    IRefreshTokenQueryObject ForId(Guid id);
    IRefreshTokenQueryObject ForUser(Guid userId);
    IRefreshTokenQueryObject ForExpired(bool state);
    IRefreshTokenQueryObject ForToken(string token);
    Task<List<RefreshTokenQueryData>> GetAll(CancellationToken cancellationToken);
    Task<RefreshTokenQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}
