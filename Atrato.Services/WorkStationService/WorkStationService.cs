using Atrato.Commands.WorkStationCommands.Create;
using Atrato.Commands.WorkStationCommands.Update;
using Atrato.Entities.DTO.WorkStation;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.WorkStationQueryObject;

namespace Atrato.Services.WorkStationService;

public class WorkStationService : IWorkStationService
{
    private readonly IWorkStationCreateCommand _createCommand;
    private readonly IWorkStationUpdateCommand _updateCommand;
    private readonly IWorkStationQueryObject _queryObject;

    public WorkStationService(
        IWorkStationCreateCommand createCommand,
        IWorkStationUpdateCommand updateCommand,
        IWorkStationQueryObject queryObject)
    {
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<WorkStationQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.GetAll(cancellationToken);

        return new StandardResult<List<WorkStationQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<WorkStationQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<WorkStationQueryData?>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<List<WorkStationQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForEnterprise(enterpriseId).GetAll(cancellationToken);

        return new StandardResult<List<WorkStationQueryData>>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<List<WorkStationQueryData>>> ByWorkplace(Guid workplaceId, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForWorkplace(workplaceId).GetAll(cancellationToken);

        return new StandardResult<List<WorkStationQueryData>>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<WorkStationQueryData>> Post(WorkStationCreateRequest request, Guid userId)
    {
        var response = await _createCommand.Execute(request, userId);

        return new StandardResult<WorkStationQueryData>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<WorkStationQueryData>> Put(WorkStationUpdateRequest request, Guid userId)
    {
        var response = await _updateCommand.Execute(request, userId);

        return new StandardResult<WorkStationQueryData>()
        {
            Success = true,
            Data = response
        };
    }
}
