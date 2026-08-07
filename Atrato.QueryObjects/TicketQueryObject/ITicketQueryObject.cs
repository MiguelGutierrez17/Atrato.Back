using Atrato.Entities.DTO.Ticket;

namespace Atrato.QueryObjects.TicketQueryObject;

public interface ITicketQueryObject
{
    ITicketQueryObject Clear();
    ITicketQueryObject ForId(Guid id);
    ITicketQueryObject ForWorkStation(Guid workStationId);
    ITicketQueryObject ForUser(Guid userId);
    ITicketQueryObject ForTicketState(Guid ticketStateId);
    ITicketQueryObject ForEnterprise(Guid enterpriseId);
    Task<List<TicketQueryData>> GetAll(CancellationToken cancellationToken);
    Task<TicketQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}
