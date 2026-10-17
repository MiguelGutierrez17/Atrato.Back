using Atrato.Commands.UserCommands.Create;
using Atrato.Commands.UserCommands.Update;
using Atrato.Entities.DTO.User;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.UserQueryObject;

namespace Atrato.Services.UserService;

public class UserService : IUserService
{
    private readonly IUserCreateCommand _createCommand;
    private readonly IUserUpdateCommand _updateCommand;
    private readonly IUserQueryObject _queryObject;

    public UserService(
        IUserCreateCommand createCommand,
        IUserUpdateCommand updateCommand,
        IUserQueryObject queryObject)
    {
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<UserQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().GetAll(cancellationToken);

        return new StandardResult<List<UserQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<UserQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<UserQueryData?>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<List<UserQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForEnterprise(enterpriseId).GetAll(cancellationToken);

        return new StandardResult<List<UserQueryData>>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<UserQueryData>> Post(UserCreateRequest request, Guid userId)
    {
        var response = await _createCommand.Execute(request, userId);

        return new StandardResult<UserQueryData>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<UserQueryData>> Put(UserUpdateRequest request, Guid userId)
    {
        var response = await _updateCommand.Execute(request, userId);

        return new StandardResult<UserQueryData>()
        {
            Success = true,
            Data = response
        };
    }
}
