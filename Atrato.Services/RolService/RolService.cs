using Atrato.Commands.RolCommands.Create;
using Atrato.Commands.RolCommands.Update;
using Atrato.Entities.DTO.Rol;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.RolQueryObject;

namespace Atrato.Services.RolService;

public class RolService : IRolService
{
    private readonly IRolCreateCommand _createCommand;
    private readonly IRolUpdateCommand _updateCommand;
    private readonly IRolQueryObject _queryObject;

    public RolService(
        IRolCreateCommand createCommand,
        IRolUpdateCommand updateCommand,
        IRolQueryObject queryObject)
    {
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<RolQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().GetAll(cancellationToken);

        return new StandardResult<List<RolQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<RolQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<RolQueryData?>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<List<RolQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForEnterprise(enterpriseId).GetAll(cancellationToken);

        return new StandardResult<List<RolQueryData>>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<RolQueryData>> Post(RolCreateRequest request, Guid userId)
    {
        var response = await _createCommand.Execute(request, userId);

        return new StandardResult<RolQueryData>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<RolQueryData>> Put(RolUpdateRequest request, Guid userId)
    {
        var response = await _updateCommand.Execute(request, userId);

        return new StandardResult<RolQueryData>()
        {
            Success = true,
            Data = response
        };
    }
}