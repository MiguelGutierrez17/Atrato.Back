using Atrato.Commands.ChangeHistoryCommands.Create;
using Atrato.Commands.ChangeHistoryCommands.Update;
using Atrato.Entities.DTO.ChangeHistory;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.ChangeHistoryQueryObject;

namespace Atrato.Services.ChangeHistoryService;

public class ChangeHistoryService : IChangeHistoryService
{
    private readonly IChangeHistoryCreateCommand _createCommand;
    private readonly IChangeHistoryUpdateCommand _updateCommand;
    private readonly IChangeHistoryQueryObject _queryObject;

    public ChangeHistoryService(
        IChangeHistoryCreateCommand createCommand,
        IChangeHistoryUpdateCommand updateCommand,
        IChangeHistoryQueryObject queryObject)
    {
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<ChangeHistoryQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.GetAll(cancellationToken);

        return new StandardResult<List<ChangeHistoryQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<ChangeHistoryQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<ChangeHistoryQueryData?>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<List<ChangeHistoryQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForEnterprise(enterpriseId).GetAll(cancellationToken);

        return new StandardResult<List<ChangeHistoryQueryData>>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<ChangeHistoryQueryData>> Post(ChangeHistoryCreateRequest request, Guid userId)
    {
        var response = await _createCommand.Execute(request, userId);

        return new StandardResult<ChangeHistoryQueryData>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<ChangeHistoryQueryData>> Put(ChangeHistoryUpdateRequest request, Guid userId)
    {
        var response = await _updateCommand.Execute(request, userId);

        return new StandardResult<ChangeHistoryQueryData>()
        {
            Success = true,
            Data = response
        };
    }
}
