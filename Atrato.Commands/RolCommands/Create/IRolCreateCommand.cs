using Atrato.Entities.DTO.Rol;

namespace Atrato.Commands.RolCommands.Create;

public interface IRolCreateCommand
{
    Task<RolQueryData> Execute(RolCreateRequest request, Guid userId);
}