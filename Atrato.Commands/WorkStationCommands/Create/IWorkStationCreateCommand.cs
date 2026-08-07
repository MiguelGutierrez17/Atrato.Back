using Atrato.Entities.DTO.WorkStation;

namespace Atrato.Commands.WorkStationCommands.Create;

public interface IWorkStationCreateCommand
{
    Task<WorkStationQueryData> Execute(WorkStationCreateRequest request, Guid userId);
}