using Atrato.Commands.WorkplaceCommands.Create;
using Atrato.Commands.WorkplaceCommands.Update;
using Atrato.Entities.DTO.Workplace;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.WorkplaceQueryObject;

namespace Atrato.Services.WorkplaceService;

public class WorkplaceService : IWorkplaceService
{
    private readonly IWorkplaceCreateCommand _createCommand;
    private readonly IWorkplaceUpdateCommand _updateCommand;
    private readonly IWorkplaceQueryObject _queryObject;

    public WorkplaceService(
        IWorkplaceCreateCommand createCommand,
        IWorkplaceUpdateCommand updateCommand,
        IWorkplaceQueryObject queryObject)
    {
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<WorkplaceQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.GetAll(cancellationToken);

        return new StandardResult<List<WorkplaceQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<WorkplaceQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<WorkplaceQueryData?>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<List<WorkplaceQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForEnterprise(enterpriseId).GetAll(cancellationToken);

        return new StandardResult<List<WorkplaceQueryData>>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<WorkplaceQueryData>> Post(WorkplaceCreateRequest request, Guid userId)
    {
        var response = await _createCommand.Execute(request, userId);

        return new StandardResult<WorkplaceQueryData>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<WorkplaceQueryData>> Put(WorkplaceUpdateRequest request, Guid userId)
    {
        var response = await _updateCommand.Execute(request, userId);

        return new StandardResult<WorkplaceQueryData>()
        {
            Success = true,
            Data = response
        };
    }
}