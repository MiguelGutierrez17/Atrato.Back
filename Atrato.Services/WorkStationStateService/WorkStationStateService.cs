using Atrato.Entities.DTO.WorkStationState;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.WorkStationStateQueryObject;

namespace Atrato.Services.WorkStationStateService;

public class WorkStationStateService : IWorkStationStateService
{
    private readonly IWorkStationStateQueryObject _queryObject;

    public WorkStationStateService(IWorkStationStateQueryObject queryObject)
    {
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<WorkStationStateQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().GetAll(cancellationToken);

        return new StandardResult<List<WorkStationStateQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<WorkStationStateQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<WorkStationStateQueryData?>()
        {
            Success = true,
            Data = response
        };
    }
}
