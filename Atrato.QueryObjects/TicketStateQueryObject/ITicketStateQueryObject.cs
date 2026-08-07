using Atrato.Entities.DTO.TicketState;

namespace Atrato.QueryObjects.TicketStateQueryObject;

public interface ITicketStateQueryObject
{
    ITicketStateQueryObject Clear();
    ITicketStateQueryObject ForId(Guid id);
    Task<List<TicketStateQueryData>> GetAll(CancellationToken cancellationToken);
    Task<TicketStateQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}
