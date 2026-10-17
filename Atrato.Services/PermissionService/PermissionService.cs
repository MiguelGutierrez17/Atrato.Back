using Atrato.Commands.PermissionCommands.Create;
using Atrato.Commands.PermissionCommands.Update;
using Atrato.Entities.DTO.Permission;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.PermissionQueryObject;

namespace Atrato.Services.PermissionService;

public class PermissionService : IPermissionService
{
    private readonly IPermissionCreateCommand _createCommand;
    private readonly IPermissionUpdateCommand _updateCommand;
    private readonly IPermissionQueryObject _queryObject;

    public PermissionService(
        IPermissionCreateCommand createCommand,
        IPermissionUpdateCommand updateCommand,
        IPermissionQueryObject queryObject)
    {
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<PermissionQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().GetAll(cancellationToken);

        return new StandardResult<List<PermissionQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<PermissionQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<PermissionQueryData?>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<PermissionQueryData>> Post(PermissionCreateRequest request, Guid userId)
    {
        var response = await _createCommand.Execute(request, userId);

        return new StandardResult<PermissionQueryData>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<PermissionQueryData>> Put(PermissionUpdateRequest request, Guid userId)
    {
        var response = await _updateCommand.Execute(request, userId);

        return new StandardResult<PermissionQueryData>()
        {
            Success = true,
            Data = response
        };
    }
}
