using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.RefreshToken;

namespace Atrato.Commands.RefreshTokenCommands.Update;

public class RefreshTokenUpdateCommand : IRefreshTokenUpdateCommand
{
    private readonly AtratoContext _context;

    public RefreshTokenUpdateCommand(AtratoContext context)
    {
        _context = context;
    }

    public async Task<RefreshTokenQueryData> Execute(RefreshTokenUpdateRequest request, Guid userId)
    {
        RefreshToken doc = new()
        {
            Id = request.Id,
            CreationDate = request.CreationDate,
            ExpirationDate = request.ExpirationDate,
            ExpiredAt = request.ExpiredAt,
            isExpired = request.isExpired,
            Token = request.Token,
            UserId = request.UserId,
        };

        _context.Update(doc);
        await _context.SaveChangesAsync();

        return new RefreshTokenQueryData()
        {
            Id = doc.Id,
            CreationDate = doc.CreationDate,
            ExpirationDate = doc.ExpirationDate,
            ExpiredAt = doc.ExpiredAt,
            isExpired = doc.isExpired,
            Token = doc.Token,
            UserId = doc.UserId,
        };
    }
}
