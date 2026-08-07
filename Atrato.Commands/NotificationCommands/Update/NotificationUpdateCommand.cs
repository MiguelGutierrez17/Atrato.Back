using Atrato.Commands.NotificationAuditCommands.Create;
using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Notification;
using Atrato.Entities.Extensions;
using Atrato.Entities.SupportDTO;

namespace Atrato.Commands.NotificationCommands.Update;

public class NotificationUpdateCommand : INotificationUpdateCommand
{
    private readonly AtratoContext _context;
    private readonly INotificationAuditCreateCommand _auditCreateCommand;

    public NotificationUpdateCommand(AtratoContext context, INotificationAuditCreateCommand auditCreateCommand)
    {
        _context = context;
        _auditCreateCommand = auditCreateCommand;
    }

    public async Task<NotificationQueryData> Execute(NotificationUpdateRequest request, Guid userId)
    {
        Notification doc = new()
        {
            Id = request.Id,
            Date = request.Date,
            Description = request.Description,
            EmailReceipter = request.EmailReceipter,
            EmailSender = request.EmailSender,
            EnterpriseId = request.EnterpriseId,
            EntityTypeId = request.EntityTypeId,
            isEmail = request.isEmail,
            Read = request.Read,
            Receipter = request.Receipter,
            State = request.State,
        };

        _context.Update(doc);
        await _context.SaveChangesAsync();

        await _auditCreateCommand.Execute(doc.CastToAuditRequest(AuditAction.Update, userId));

        return new NotificationQueryData()
        {
            Id = doc.Id,
            Date = doc.Date,
            Description = doc.Description,
            EmailReceipter = doc.EmailReceipter,
            EmailSender = doc.EmailSender,
            EnterpriseId = doc.EnterpriseId,
            EntityTypeId = doc.EntityTypeId,
            isEmail = doc.isEmail,
            Read = doc.Read,
            Receipter = doc.Receipter,
            State = doc.State,
        };
    }
}