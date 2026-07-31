using Atrato.Entities.SupportDTO;

namespace Atrato.Services.AuthService;

public class AuthService : IAuthService
{
    public Task<StandardResult<AuthToken>> Login(AuthRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<StandardResult<AuthToken>> Refresh(AuthToken request)
    {
        throw new NotImplementedException();
    }
}