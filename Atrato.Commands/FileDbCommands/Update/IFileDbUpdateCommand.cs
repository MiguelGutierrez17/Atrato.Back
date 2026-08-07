using Atrato.Entities.DTO.FileDb;

namespace Atrato.Commands.FileDbCommands.Update;

public interface IFileDbUpdateCommand
{
    Task<FileDbQueryData> Execute(FileDbUpdateRequest request, Guid userId);
}