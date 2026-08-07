using Atrato.Entities.DTO.ReservationType;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.ReservationTypeService;

public interface IReservationTypeService
{
    Task<StandardResult<List<ReservationTypeQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<ReservationTypeQueryData?>> ById(Guid id, CancellationToken cancellationToken);
}
