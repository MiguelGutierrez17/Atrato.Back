using Atrato.Commands.NotificationAuditCommands.Create;
using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Notification;
using Atrato.Entities.Extensions;
using Atrato.Entities.SupportDTO;

namespace Atrato.Commands.NotificationCommands.Create;

public class NotificationCreateCommand : INotificationCreateCommand
{
    private readonly AtratoContext _context;
    private readonly INotificationAuditCreateCommand _auditCreateCommand;

    public NotificationCreateCommand(AtratoContext context, INotificationAuditCreateCommand auditCreateCommand)
    {
        _context = context;
        _auditCreateCommand = auditCreateCommand;
    }

    public async Task<NotificationQueryData> Execute(NotificationCreateRequest request, Guid userId)
    {
        Notification doc = new()
        {
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

        _context.Add(doc);
        await _context.SaveChangesAsync();

        await _auditCreateCommand.Execute(doc.CastToAuditRequest(AuditAction.Create, userId));

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