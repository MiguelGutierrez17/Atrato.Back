using Atrato.Entities.DTO.ReservationState;

namespace Atrato.QueryObjects.ReservationStateQueryObject;

public interface IReservationStateQueryObject
{
    IReservationStateQueryObject Clear();
    IReservationStateQueryObject ForId(Guid id);
    Task<List<ReservationStateQueryData>> GetAll(CancellationToken cancellationToken);
    Task<ReservationStateQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}
