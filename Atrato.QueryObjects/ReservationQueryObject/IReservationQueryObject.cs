using Atrato.Entities.DTO.Reservation;

namespace Atrato.QueryObjects.ReservationQueryObject;

public interface IReservationQueryObject
{
    IReservationQueryObject Clear();
    IReservationQueryObject ForId(Guid id);
    IReservationQueryObject ForEnterprise(Guid enterpriseId);
    IReservationQueryObject ForWorkplace(Guid workplaceId);
    IReservationQueryObject ForWorkStation(Guid workStationId);
    IReservationQueryObject ForUser(Guid userId);
    IReservationQueryObject ForReservationState(Guid reservationStateId);
    IReservationQueryObject ForReservationType(Guid reservationTypeId);
    IReservationQueryObject ForStartDateGreaterThan(DateTime startDate);
    IReservationQueryObject ForStartDateLessThan(DateTime startDate);
    IReservationQueryObject ForEndDateGreaterThan(DateTime endDate);
    IReservationQueryObject ForEndDateLessThan(DateTime endDate);
    Task<List<ReservationQueryData>> GetAll(CancellationToken cancellationToken);
    Task<ReservationQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}
