using Atrato.Entities.DTO.News;

namespace Atrato.Commands.NewsCommands.Create;

public interface INewsCreateCommand
{
    Task<NewsQueryData> Execute(NewsCreateRequest request, Guid userId);
}