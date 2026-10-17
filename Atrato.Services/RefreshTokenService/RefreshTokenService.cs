using Atrato.Commands.RefreshTokenCommands.Create;
using Atrato.Commands.RefreshTokenCommands.Update;
using Atrato.Entities.DTO.RefreshToken;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.RefreshTokenQueryObject;

namespace Atrato.Services.RefreshTokenService;

public class RefreshTokenService : IRefreshTokenService
{
    private readonly IRefreshTokenCreateCommand _createCommand;
    private readonly IRefreshTokenUpdateCommand _updateCommand;
    private readonly IRefreshTokenQueryObject _queryObject;

    public RefreshTokenService(
        IRefreshTokenCreateCommand createCommand,
        IRefreshTokenUpdateCommand updateCommand,
        IRefreshTokenQueryObject queryObject)
    {
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<RefreshTokenQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().GetAll(cancellationToken);

        return new StandardResult<List<RefreshTokenQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<RefreshTokenQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<RefreshTokenQueryData?>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<List<RefreshTokenQueryData>>> ByUser(Guid userId, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForUser(userId).GetAll(cancellationToken);

        return new StandardResult<List<RefreshTokenQueryData>>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<RefreshTokenQueryData>> Post(RefreshTokenCreateRequest request, Guid userId)
    {
        var response = await _createCommand.Execute(request, userId);

        return new StandardResult<RefreshTokenQueryData>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<RefreshTokenQueryData>> Put(RefreshTokenUpdateRequest request, Guid userId)
    {
        var response = await _updateCommand.Execute(request, userId);

        return new StandardResult<RefreshTokenQueryData>()
        {
            Success = true,
            Data = response
        };
    }
}
