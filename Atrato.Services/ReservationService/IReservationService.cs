using Atrato.Entities.DTO.Reservation;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.ReservationService;

public interface IReservationService
{
    Task<StandardResult<List<ReservationQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<ReservationQueryData?>> ById(Guid id, CancellationToken cancellationToken);
    Task<StandardResult<List<ReservationQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken);
    Task<StandardResult<List<ReservationQueryData>>> ByWorkplace(Guid workplaceId, CancellationToken cancellationToken);
    Task<StandardResult<List<ReservationQueryData>>> ByWorkStation(Guid workStationId, CancellationToken cancellationToken);
    Task<StandardResult<List<ReservationQueryData>>> ByUser(Guid userId, CancellationToken cancellationToken);
    Task<StandardResult<ReservationQueryData>> Post(ReservationCreateRequest request, Guid userId);
    Task<StandardResult<ReservationQueryData>> Put(ReservationUpdateRequest request, Guid userId);
}
