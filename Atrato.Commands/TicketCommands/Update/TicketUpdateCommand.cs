using Atrato.Commands.TicketAuditCommands.Create;
using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Ticket;
using Atrato.Entities.Extensions;
using Atrato.Entities.SupportDTO;

namespace Atrato.Commands.TicketCommands.Update;

public class TicketUpdateCommand : ITicketUpdateCommand
{
    private readonly AtratoContext _context;
    private readonly ITicketAuditCreateCommand _auditCreateCommand;

    public TicketUpdateCommand(AtratoContext context, ITicketAuditCreateCommand auditCreateCommand)
    {
        _context = context;
        _auditCreateCommand = auditCreateCommand;
    }

    public async Task<TicketQueryData> Execute(TicketUpdateRequest request, Guid userId)
    {
        Ticket doc = new()
        {
            Id = request.Id,
            Body = request.Body,
            Date = request.Date,
            TicketStateId = request.TicketStateId,
            Title = request.Title,
            UserId = request.UserId,
            WorkStationId = request.WorkStationId,
        };

        _context.Update(doc);
        await _context.SaveChangesAsync();

        await _auditCreateCommand.Execute(doc.CastToAuditRequest(AuditAction.Update, userId));

        return new TicketQueryData()
        {
            Id = doc.Id,
            Body = doc.Body,
            Date = doc.Date,
            TicketStateId = doc.TicketStateId,
            Title = doc.Title,
            UserId = doc.UserId,
            WorkStationId = doc.WorkStationId,
        };
    }
}