using Atrato.Entities.DTO.WorkStation;

namespace Atrato.Commands.WorkStationCommands.Update;

public interface IWorkStationUpdateCommand
{
    Task<WorkStationQueryData> Execute(WorkStationUpdateRequest request, Guid userId);
}