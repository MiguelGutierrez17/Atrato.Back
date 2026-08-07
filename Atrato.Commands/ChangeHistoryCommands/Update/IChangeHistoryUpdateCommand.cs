using Atrato.Entities.DTO.ChangeHistory;

namespace Atrato.Commands.ChangeHistoryCommands.Update;

public interface IChangeHistoryUpdateCommand
{
    Task<ChangeHistoryQueryData> Execute(ChangeHistoryUpdateRequest request, Guid userId);
}
