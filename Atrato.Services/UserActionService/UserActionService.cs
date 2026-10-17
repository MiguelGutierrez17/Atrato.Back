using Atrato.Entities.DTO.UserAction;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.UserActionQueryObject;

namespace Atrato.Services.UserActionService;

public class UserActionService : IUserActionService
{
    private readonly IUserActionQueryObject _queryObject;

    public UserActionService(IUserActionQueryObject queryObject)
    {
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<UserActionQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().GetAll(cancellationToken);

        return new StandardResult<List<UserActionQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<UserActionQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<UserActionQueryData?>()
        {
            Success = true,
            Data = response
        };
    }
}
