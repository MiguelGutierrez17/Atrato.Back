using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Invitation;

namespace Atrato.Commands.InvitationCommands.Create;

public class InvitationCreateCommand : IInvitationCreateCommand
{
    private readonly AtratoContext _context;

    public InvitationCreateCommand(AtratoContext context)
    {
        _context = context;
    }

    public async Task<InvitationQueryData> Execute(InvitationCreateRequest request, Guid userId)
    {
        Invitation doc = new()
        {
            Code = request.Code,
            State = request.State,
            NumberAttempts = request.NumberAttempts,
            CreationDate = request.CreationDate,
            ExpirationDate = request.ExpirationDate,
            UsedAt = request.UsedAt,
            UserId = request.UserId,
        };

        _context.Add(doc);
        await _context.SaveChangesAsync();

        return new InvitationQueryData()
        {
            Id = doc.Id,
            Code = doc.Code,
            State = doc.State,
            NumberAttempts = doc.NumberAttempts,
            CreationDate = doc.CreationDate,
            ExpirationDate = doc.ExpirationDate,
            UsedAt = doc.UsedAt,
            UserId = doc.UserId,
        };
    }
}
