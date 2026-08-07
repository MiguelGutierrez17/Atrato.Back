using Atrato.Commands.NewsCommands.Create;
using Atrato.Commands.NewsCommands.Update;
using Atrato.Entities.DTO.News;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.NewsQueryObject;

namespace Atrato.Services.NewsService;

public class NewsService : INewsService
{
    private readonly INewsCreateCommand _createCommand;
    private readonly INewsUpdateCommand _updateCommand;
    private readonly INewsQueryObject _queryObject;

    public NewsService(
        INewsCreateCommand createCommand,
        INewsUpdateCommand updateCommand,
        INewsQueryObject queryObject)
    {
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<NewsQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.GetAll(cancellationToken);

        return new StandardResult<List<NewsQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<NewsQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<NewsQueryData?>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<List<NewsQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForEnterprise(enterpriseId).GetAll(cancellationToken);

        return new StandardResult<List<NewsQueryData>>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<NewsQueryData>> Post(NewsCreateRequest request, Guid userId)
    {
        var response = await _createCommand.Execute(request, userId);

        return new StandardResult<NewsQueryData>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<NewsQueryData>> Put(NewsUpdateRequest request, Guid userId)
    {
        var response = await _updateCommand.Execute(request, userId);

        return new StandardResult<NewsQueryData>()
        {
            Success = true,
            Data = response
        };
    }
}