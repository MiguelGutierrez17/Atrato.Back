using Atrato.Commands.UserAuditCommands.Create;
using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.User;
using Atrato.Entities.Extensions;
using Atrato.Entities.SupportDTO;

namespace Atrato.Commands.UserCommands.Create;

public class UserCreateCommand : IUserCreateCommand
{
    private readonly AtratoContext _context;
    private readonly IUserAuditCreateCommand _auditCreateCommand;

    public UserCreateCommand(AtratoContext context, IUserAuditCreateCommand auditCreateCommand)
    {
        _context = context;
        _auditCreateCommand = auditCreateCommand;
    }

    public async Task<UserQueryData> Execute(UserCreateRequest request, Guid userId)
    {
        User doc = new()
        {
            Email = request.Email,
            Initials = request.Initials,
            isSuperAdmin = request.isSuperAdmin,
            LastName = request.LastName,
            Name = request.Name,
            Phone = request.Phone,
            State = request.State,
        };

        _context.Add(doc);
        await _context.SaveChangesAsync();

        await _auditCreateCommand.Execute(doc.CastToAuditRequest(AuditAction.Create, userId));

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