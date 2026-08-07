using Atrato.Entities.DTO.Invitation;

namespace Atrato.QueryObjects.InvitationQueryObject;

public interface IInvitationQueryObject
{
    IInvitationQueryObject Clear();
    IInvitationQueryObject ForId(Guid id);
    IInvitationQueryObject ForState(bool state);
    IInvitationQueryObject ForUser(Guid userId);
    IInvitationQueryObject ForUserEmail(string email);
    IInvitationQueryObject ForCode(string code);
    Task<List<InvitationQueryData>> GetAll(CancellationToken cancellationToken);
    Task<InvitationQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}
