using Atrato.Commands.AddressCommands.Create;
using Atrato.Commands.AddressCommands.Update;
using Atrato.Entities.DTO.Address;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.AddressQueryObject;

namespace Atrato.Services.AddressService;

public class AddressService : IAddressService
{
    private readonly IAddressCreateCommand _createCommand;
    private readonly IAddressUpdateCommand _updateCommand;
    private readonly IAddressQueryObject _queryObject;

    public AddressService(
        IAddressCreateCommand createCommand,
        IAddressUpdateCommand updateCommand,
        IAddressQueryObject queryObject)
    {
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<AddressQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().GetAll(cancellationToken);

        return new StandardResult<List<AddressQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<AddressQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<AddressQueryData?>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<List<AddressQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForEnterprise(enterpriseId).GetAll(cancellationToken);

        return new StandardResult<List<AddressQueryData>>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<AddressQueryData>> Post(AddressCreateRequest request, Guid userId)
    {
        var response = await _createCommand.Execute(request, userId);

        return new StandardResult<AddressQueryData>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<AddressQueryData>> Put(AddressUpdateRequest request, Guid userId)
    {
        var response = await _updateCommand.Execute(request, userId);

        return new StandardResult<AddressQueryData>()
        {
            Success = true,
            Data = response
        };
    }
}