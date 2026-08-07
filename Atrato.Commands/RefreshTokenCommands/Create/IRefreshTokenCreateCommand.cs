using Atrato.Entities.DTO.RefreshToken;

namespace Atrato.Commands.RefreshTokenCommands.Create;

public interface IRefreshTokenCreateCommand
{
    Task<RefreshTokenQueryData> Execute(RefreshTokenCreateRequest request, Guid userId);
}
