using Atrato.Entities.DTO.Area;

namespace Atrato.Commands.AreaCommands.Create;

public interface IAreaCreateCommand
{
    Task<AreaQueryData> Execute(AreaCreateRequest request, Guid userId);
}
