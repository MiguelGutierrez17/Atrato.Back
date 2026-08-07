using Atrato.Entities.DTO.User;

namespace Atrato.Commands.UserCommands.Create;

public interface IUserCreateCommand
{
    Task<UserQueryData> Execute(UserCreateRequest request, Guid userId);
}