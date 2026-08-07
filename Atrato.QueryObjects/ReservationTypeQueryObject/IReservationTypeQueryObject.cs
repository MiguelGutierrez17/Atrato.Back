using Atrato.Entities.DTO.ReservationType;

namespace Atrato.QueryObjects.ReservationTypeQueryObject;

public interface IReservationTypeQueryObject
{
    IReservationTypeQueryObject Clear();
    IReservationTypeQueryObject ForId(Guid id);
    Task<List<ReservationTypeQueryData>> GetAll(CancellationToken cancellationToken);
    Task<ReservationTypeQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}
