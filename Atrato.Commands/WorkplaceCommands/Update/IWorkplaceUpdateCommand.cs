using Atrato.Entities.DTO.Workplace;

namespace Atrato.Commands.WorkplaceCommands.Update;

public interface IWorkplaceUpdateCommand
{
    Task<WorkplaceQueryData> Execute(WorkplaceUpdateRequest request, Guid userId);
}