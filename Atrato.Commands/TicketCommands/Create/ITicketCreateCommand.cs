using Atrato.Entities.DTO.Ticket;

namespace Atrato.Commands.TicketCommands.Create;

public interface ITicketCreateCommand
{
    Task<TicketQueryData> Execute(TicketCreateRequest request, Guid userId);
}