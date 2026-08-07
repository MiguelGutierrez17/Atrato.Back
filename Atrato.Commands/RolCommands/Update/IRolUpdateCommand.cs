using Atrato.Entities.DTO.Rol;

namespace Atrato.Commands.RolCommands.Update;

public interface IRolUpdateCommand
{
    Task<RolQueryData> Execute(RolUpdateRequest request, Guid userId);
}