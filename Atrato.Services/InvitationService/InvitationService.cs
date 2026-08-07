using Atrato.Commands.InvitationCommands.Create;
using Atrato.Commands.InvitationCommands.Update;
using Atrato.Entities.DTO.Invitation;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.InvitationQueryObject;

namespace Atrato.Services.InvitationService;

public class InvitationService : IInvitationService
{
    private readonly IInvitationCreateCommand _createCommand;
    private readonly IInvitationUpdateCommand _updateCommand;
    private readonly IInvitationQueryObject _queryObject;

    public InvitationService(
        IInvitationCreateCommand createCommand,
        IInvitationUpdateCommand updateCommand,
        IInvitationQueryObject queryObject)
    {
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<InvitationQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.GetAll(cancellationToken);

        return new StandardResult<List<InvitationQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<InvitationQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<InvitationQueryData?>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<List<InvitationQueryData>>> ByUser(Guid userId, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForUser(userId).GetAll(cancellationToken);

        return new StandardResult<List<InvitationQueryData>>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<InvitationQueryData>> Post(InvitationCreateRequest request, Guid userId)
    {
        var response = await _createCommand.Execute(request, userId);

        return new StandardResult<InvitationQueryData>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<InvitationQueryData>> Put(InvitationUpdateRequest request, Guid userId)
    {
        var response = await _updateCommand.Execute(request, userId);

        return new StandardResult<InvitationQueryData>()
        {
            Success = true,
            Data = response
        };
    }
}
