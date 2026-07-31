using Atrato.Entities.SupportDTO;

namespace Atrato.Services.AuthService;

public interface IAuthService
{
    Task<StandardResult<AuthToken>> Login(AuthRequest request);
    Task<StandardResult<AuthToken>> Refresh(AuthToken request);
}