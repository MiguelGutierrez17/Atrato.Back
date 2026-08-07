using Atrato.Entities.SupportDTO;

namespace Atrato.Services.AuthService;

public interface IAuthService
{
    Task<StandardResult<bool>> CheckUser(string email, CancellationToken cancellationToken);
    Task<StandardResult<AuthToken>> Login(AuthRequest request, CancellationToken cancellationToken);
    Task<StandardResult<AuthToken>> Refresh(AuthToken request, CancellationToken cancellationToken);
}