using Atrato.Entities.DTO.Area;

namespace Atrato.Commands.AreaCommands.Update;

public interface IAreaUpdateCommand
{
    Task<AreaQueryData> Execute(AreaUpdateRequest request, Guid userId);
}