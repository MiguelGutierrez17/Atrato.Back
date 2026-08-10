namespace Atrato.Commands.InvitationCommands.RegisterFailedAttempt;

public interface IInvitationRegisterFailedAttemptCommand
{
    Task<int> Execute(Guid invitationId, int maxAttempts, CancellationToken cancellationToken);
}