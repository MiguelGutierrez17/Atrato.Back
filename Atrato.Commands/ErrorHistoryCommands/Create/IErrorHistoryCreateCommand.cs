using Atrato.Entities.DTO.ErrorHistory;

namespace Atrato.Commands.ErrorHistoryCommands.Create;

public interface IErrorHistoryCreateCommand
{
    Task<ErrorHistoryQueryData> Execute(ErrorHistoryCreateRequest request, Guid userId);
}