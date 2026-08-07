using Atrato.Entities.DTO.RefreshToken;

namespace Atrato.Commands.RefreshTokenCommands.Update;

public interface IRefreshTokenUpdateCommand
{
    Task<RefreshTokenQueryData> Execute(RefreshTokenUpdateRequest request, Guid userId);
}
