using Atrato.Entities.DTO.User;

namespace Atrato.Commands.UserCommands.Update;

public interface IUserUpdateCommand
{
    Task<UserQueryData> Execute(UserUpdateRequest request, Guid userId);
}