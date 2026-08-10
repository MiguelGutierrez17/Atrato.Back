using Atrato.Entities.SupportDTO;

namespace Atrato.Services.AuthService;

public interface IAuthService
{
    Task<StandardResult<bool>> RequestCode(CheckUserRequest request, CancellationToken cancellationToken);
    Task<StandardResult<AuthToken>> Login(AuthRequest request, CancellationToken cancellationToken);
    Task<StandardResult<AuthToken>> Refresh(RefreshRequest request, CancellationToken cancellationToken);
}