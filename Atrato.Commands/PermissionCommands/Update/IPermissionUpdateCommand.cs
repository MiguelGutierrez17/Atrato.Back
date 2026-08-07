using Atrato.Entities.DTO.Permission;

namespace Atrato.Commands.PermissionCommands.Update;

public interface IPermissionUpdateCommand
{
    Task<PermissionQueryData> Execute(PermissionUpdateRequest request, Guid userId);
}
