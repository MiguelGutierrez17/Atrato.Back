using Atrato.Commands.UserAuditCommands.Create;
using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.User;
using Atrato.Entities.Extensions;
using Atrato.Entities.SupportDTO;

namespace Atrato.Commands.UserCommands.Update;

public class UserUpdateCommand : IUserUpdateCommand
{
    private readonly AtratoContext _context;
    private readonly IUserAuditCreateCommand _auditCreateCommand;

    public UserUpdateCommand(AtratoContext context, IUserAuditCreateCommand auditCreateCommand)
    {
        _context = context;
        _auditCreateCommand = auditCreateCommand;
    }

    public async Task<UserQueryData> Execute(UserUpdateRequest request, Guid userId)
    {
        User doc = new()
        {
            Id = request.Id,
            Email = request.Email,
            Initials = request.Initials,
            isSuperAdmin = request.isSuperAdmin,
            LastName = request.LastName,
            Name = request.Name,
            Phone = request.Phone,
            State = request.State,
        };

        _context.Update(doc);
        await _context.SaveChangesAsync();

        await _auditCreateCommand.Execute(doc.CastToAuditRequest(AuditAction.Update, userId));

        return new UserQueryData()
        {
            Id = doc.Id,
            Email = doc.Email,
            Initials = doc.Initials,
            isSuperAdmin = doc.isSuperAdmin,
            LastName = doc.LastName,
            Name = doc.Name,
            Phone = doc.Phone,
            State = doc.State,
        };
    }
}