using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.TicketAudit;

namespace Atrato.Commands.TicketAuditCommands.Create;

public class TicketAuditCreateCommand : ITicketAuditCreateCommand
{
    private readonly AtratoAuditContext _auditContext;

    public TicketAuditCreateCommand(AtratoAuditContext auditContext)
    {
        _auditContext = auditContext;
    }

    public Task Execute(TicketAuditCreateRequest request)
    {
        TicketAudit doc = new()
        {
            AuditAction = request.AuditAction,
            Body = request.Body,
            Date = request.Date,
            DateChange = request.DateChange,
            ItemId = request.ItemId,
            TicketStateId = request.TicketStateId,
            Title = request.Title,
            UserChange = request.UserChange,
            UserId = request.UserId,
            WorkStationId = request.WorkStationId,
        };

        _auditContext.Add(doc);

        return Task.CompletedTask;
    }
}