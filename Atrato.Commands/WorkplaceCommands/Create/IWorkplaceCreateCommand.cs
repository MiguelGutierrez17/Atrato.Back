using Atrato.Entities.DTO.Workplace;

namespace Atrato.Commands.WorkplaceCommands.Create;

public interface IWorkplaceCreateCommand
{
    Task<WorkplaceQueryData> Execute(WorkplaceCreateRequest request, Guid userId);
}