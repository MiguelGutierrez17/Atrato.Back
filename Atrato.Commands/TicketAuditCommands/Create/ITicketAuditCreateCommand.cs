using Atrato.Entities.DTO.TicketAudit;

namespace Atrato.Commands.TicketAuditCommands.Create;

public interface ITicketAuditCreateCommand
{
    Task Execute(TicketAuditCreateRequest request);
}