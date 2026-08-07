using Atrato.Entities.DTO.Invitation;

namespace Atrato.Commands.InvitationCommands.Create;

public interface IInvitationCreateCommand
{
    Task<InvitationQueryData> Execute(InvitationCreateRequest request, Guid userId);
}
