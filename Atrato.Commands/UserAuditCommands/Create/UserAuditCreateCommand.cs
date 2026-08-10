using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.UserAudit;

namespace Atrato.Commands.UserAuditCommands.Create;

public class UserAuditCreateCommand : IUserAuditCreateCommand
{
    private readonly AtratoAuditContext _auditContext;

    public UserAuditCreateCommand(AtratoAuditContext auditContext)
    {
        _auditContext = auditContext;
    }

    public Task Execute(UserAuditCreateRequest request)
    {
        UserAudit doc = new()
        {
            AuditAction = request.AuditAction,
            DateChange = request.DateChange,
            Email = request.Email,
            Initials = request.Initials,
            isSuperAdmin = request.isSuperAdmin,
            ItemId = request.ItemId,
            LastName = request.LastName,
            Name = request.Name,
            Phone = request.Phone,
            State = request.State,
            UserChange = request.UserChange,
        };

        _auditContext.Add(doc);

        return Task.CompletedTask;
    }
}