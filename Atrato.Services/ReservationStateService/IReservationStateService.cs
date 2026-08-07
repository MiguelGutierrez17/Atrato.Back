using Atrato.Entities.DTO.ReservationState;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.ReservationStateService;

public interface IReservationStateService
{
    Task<StandardResult<List<ReservationStateQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<ReservationStateQueryData?>> ById(Guid id, CancellationToken cancellationToken);
}
