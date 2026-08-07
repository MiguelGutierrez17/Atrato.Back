using Atrato.Entities.DTO.Ticket;

namespace Atrato.Commands.TicketCommands.Update;

public interface ITicketUpdateCommand
{
    Task<TicketQueryData> Execute(TicketUpdateRequest request, Guid userId);
}