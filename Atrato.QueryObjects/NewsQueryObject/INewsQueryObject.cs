using Atrato.Entities.DTO.News;

namespace Atrato.QueryObjects.NewsQueryObject;

public interface INewsQueryObject
{
    INewsQueryObject Clear();
    INewsQueryObject ForId(Guid id);
    INewsQueryObject ForState(bool state);
    INewsQueryObject ForEnterprise(Guid enterpriseId);
    INewsQueryObject ForFile(Guid fileId);
    Task<List<NewsQueryData>> GetAll(CancellationToken cancellationToken);
    Task<NewsQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}