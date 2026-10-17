using Atrato.Commands.AreaCommands.Create;
using Atrato.Commands.AreaCommands.Update;
using Atrato.Entities.DTO.Area;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.AreaQueryObject;

namespace Atrato.Services.AreaService;

public class AreaService : IAreaService
{
    private readonly IAreaCreateCommand _createCommand;
    private readonly IAreaUpdateCommand _updateCommand;
    private readonly IAreaQueryObject _queryObject;

    public AreaService(
        IAreaCreateCommand createCommand,
        IAreaUpdateCommand updateCommand,
        IAreaQueryObject queryObject)
    {
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<AreaQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().GetAll(cancellationToken);

        return new StandardResult<List<AreaQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<AreaQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<AreaQueryData?>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<List<AreaQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForEnterprise(enterpriseId).GetAll(cancellationToken);

        return new StandardResult<List<AreaQueryData>>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<AreaQueryData>> Post(AreaCreateRequest request, Guid userId)
    {
        var response = await _createCommand.Execute(request, userId);

        return new StandardResult<AreaQueryData>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<AreaQueryData>> Put(AreaUpdateRequest request, Guid userId)
    {
        var response = await _updateCommand.Execute(request, userId);

        return new StandardResult<AreaQueryData>()
        {
            Success = true,
            Data = response
        };
    }
}
