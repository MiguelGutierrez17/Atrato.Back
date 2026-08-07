using Atrato.Entities.DTO.Permission;

namespace Atrato.Commands.PermissionCommands.Create;

public interface IPermissionCreateCommand
{
    Task<PermissionQueryData> Execute(PermissionCreateRequest request, Guid userId);
}
