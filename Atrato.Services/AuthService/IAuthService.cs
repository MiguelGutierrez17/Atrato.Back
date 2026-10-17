using Atrato.Entities.DTO.User;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.AuthService;

public interface IAuthService
{
    Task<StandardResult<bool>> RequestCode(CheckUserRequest request, CancellationToken cancellationToken);
    Task<StandardResult<AuthToken>> Login(AuthRequest request, CancellationToken cancellationToken);
    Task<StandardResult<AuthToken>> Refresh(RefreshRequest request, CancellationToken cancellationToken);
    Task<StandardResult<LoginUserData?>> RehydrateUser(Guid userId, CancellationToken cancellationToken);
    Task<StandardResult<bool>> Logout(LogoutRequest request, CancellationToken cancellationToken);
    Task<StandardResult<bool>> LogoutAll(Guid userId, CancellationToken cancellationToken);
}