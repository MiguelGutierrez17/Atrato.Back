using Atrato.Entities.DTO.Enterprise;

namespace Atrato.Commands.EnterpriseCommands.Update;

public interface IEnterpriseUpdateCommand
{
    Task<EnterpriseQueryData> Execute(EnterpriseUpdateRequest request, Guid userId);
}