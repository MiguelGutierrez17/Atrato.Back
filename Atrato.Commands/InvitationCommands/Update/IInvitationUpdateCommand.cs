using Atrato.Entities.DTO.Invitation;

namespace Atrato.Commands.InvitationCommands.Update;

public interface IInvitationUpdateCommand
{
    Task<InvitationQueryData> Execute(InvitationUpdateRequest request, Guid userId);
}
