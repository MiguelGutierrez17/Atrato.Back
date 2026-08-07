using Atrato.Entities.DTO.FileDb;

namespace Atrato.Commands.FileDbCommands.Create;

public interface IFileDbCreateCommand
{
    Task<FileDbQueryData> Execute(FileDbCreateRequest request, Guid userId);
}