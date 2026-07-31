using Atrato.Entities.DTO.Enterprise;

namespace Atrato.Commands.EnterpriseCommands.Create;

public interface IEnterpriseCreateCommand
{
    Task<EnterpriseQueryData> Execute(EnterpriseCreateRequest request, Guid userId);
}