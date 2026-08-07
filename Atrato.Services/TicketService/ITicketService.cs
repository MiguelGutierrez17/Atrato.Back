using Atrato.Entities.DTO.Ticket;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.TicketService;

public interface ITicketService
{
    Task<StandardResult<List<TicketQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<TicketQueryData?>> ById(Guid id, CancellationToken cancellationToken);
    Task<StandardResult<List<TicketQueryData>>> ByWorkStation(Guid workStationId, CancellationToken cancellationToken);
    Task<StandardResult<List<TicketQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken);
    Task<StandardResult<TicketQueryData>> Post(TicketCreateRequest request, Guid userId);
    Task<StandardResult<TicketQueryData>> Put(TicketUpdateRequest request, Guid userId);
}
