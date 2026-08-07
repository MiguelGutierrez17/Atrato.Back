using Atrato.Entities.DTO.TicketState;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.TicketStateService;

public interface ITicketStateService
{
    Task<StandardResult<List<TicketStateQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<TicketStateQueryData?>> ById(Guid id, CancellationToken cancellationToken);
}
