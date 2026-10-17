using Atrato.Commands.EnterpriseCommands.Create;
using Atrato.Commands.EnterpriseCommands.Update;
using Atrato.Entities.DTO.Enterprise;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.EnterpriseQueryObject;

namespace Atrato.Services.EnterpriseService;

public class EnterpriseService : IEnterpriseService
{
    private readonly IEnterpriseCreateCommand _createCommand;
    private readonly IEnterpriseUpdateCommand _updateCommand;
    private readonly IEnterpriseQueryObject _queryObject;

    public EnterpriseService(
        IEnterpriseCreateCommand createCommand,
        IEnterpriseUpdateCommand updateCommand,
        IEnterpriseQueryObject queryObject)
    {
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<EnterpriseQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().GetAll(cancellationToken);

        return new StandardResult<List<EnterpriseQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<EnterpriseQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<EnterpriseQueryData?>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<EnterpriseQueryData>> Post(EnterpriseCreateRequest request, Guid userId)
    {
        var response = await _createCommand.Execute(request, userId);

        return new StandardResult<EnterpriseQueryData>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<EnterpriseQueryData>> Put(EnterpriseUpdateRequest request, Guid userId)
    {
        var response = await _updateCommand.Execute(request, userId);

        return new StandardResult<EnterpriseQueryData>()
        {
            Success = true,
            Data = response
        };
    }
}