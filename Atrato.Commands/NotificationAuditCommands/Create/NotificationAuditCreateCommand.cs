using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.NotificationAudit;

namespace Atrato.Commands.NotificationAuditCommands.Create;

public class NotificationAuditCreateCommand : INotificationAuditCreateCommand
{
    private readonly AtratoAuditContext _auditContext;

    public NotificationAuditCreateCommand(AtratoAuditContext auditContext)
    {
        _auditContext = auditContext;
    }

    public async Task Execute(NotificationAuditCreateRequest request)
    {
        NotificationAudit doc = new()
        {
            AuditAction = request.AuditAction,
            Date = request.Date,
            DateChange = request.DateChange,
            Description = request.Description,
            EmailReceipter = request.EmailReceipter,
            EmailSender = request.EmailSender,
            EnterpriseId = request.EnterpriseId,
            EntityTypeId = request.EntityTypeId,
            isEmail = request.isEmail,
            ItemId = request.ItemId,
            Read = request.Read,
            Receipter = request.Receipter,
            State = request.State,
            UserChange = request.UserChange,
        };

        _auditContext.Add(doc);
        await _auditContext.SaveChangesAsync();
    }
}