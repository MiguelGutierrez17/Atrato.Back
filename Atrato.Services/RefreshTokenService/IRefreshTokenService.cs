using Atrato.Entities.DTO.RefreshToken;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.RefreshTokenService;

public interface IRefreshTokenService
{
    Task<StandardResult<List<RefreshTokenQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<RefreshTokenQueryData?>> ById(Guid id, CancellationToken cancellationToken);
    Task<StandardResult<List<RefreshTokenQueryData>>> ByUser(Guid userId, CancellationToken cancellationToken);
    Task<StandardResult<RefreshTokenQueryData>> Post(RefreshTokenCreateRequest request, Guid userId);
    Task<StandardResult<RefreshTokenQueryData>> Put(RefreshTokenUpdateRequest request, Guid userId);
}
