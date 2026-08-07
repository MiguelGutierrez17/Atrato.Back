using Atrato.Entities.DTO.News;

namespace Atrato.Commands.NewsCommands.Update;

public interface INewsUpdateCommand
{
    Task<NewsQueryData> Execute(NewsUpdateRequest request, Guid userId);
}