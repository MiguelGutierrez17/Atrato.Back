using Atrato.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace Atrato.Commands.InvitationCommands.RegisterFailedAttempt;

public class InvitationRegisterFailedAttemptCommand : IInvitationRegisterFailedAttemptCommand
{
    private readonly AtratoContext _context;

    public InvitationRegisterFailedAttemptCommand(AtratoContext context)
    {
        _context = context;
    }

    public async Task<int> Execute(Guid invitationId, int maxAttempts, CancellationToken cancellationToken)
    {
        var response =
            from i in _context.Invitation
            where i.Id == invitationId && i.State
            select i;

        var updated = await response.ExecuteUpdateAsync(x => x
                .SetProperty(i => i.NumberAttempts, i => i.NumberAttempts + 1)
                .SetProperty(i => i.State, i => i.NumberAttempts + 1 < maxAttempts),
            cancellationToken);

        return updated;
    }
}
