using Atrato.Entities.DTO.News;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.NewsService;

public interface INewsService
{
    Task<StandardResult<List<NewsQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<NewsQueryData?>> ById(Guid id, CancellationToken cancellationToken);
    Task<StandardResult<List<NewsQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken);
    Task<StandardResult<NewsQueryData>> Post(NewsCreateRequest request, Guid userId);
    Task<StandardResult<NewsQueryData>> Put(NewsUpdateRequest request, Guid userId);
}