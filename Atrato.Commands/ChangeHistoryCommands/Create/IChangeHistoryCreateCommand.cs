using Atrato.Entities.DTO.ChangeHistory;

namespace Atrato.Commands.ChangeHistoryCommands.Create;

public interface IChangeHistoryCreateCommand
{
    Task<ChangeHistoryQueryData> Execute(ChangeHistoryCreateRequest request, Guid userId);
}
