using Atrato.Entities.DTO.Reservation;

namespace Atrato.Commands.ReservationCommands.Update;

public interface IReservationUpdateCommand
{
    Task<ReservationQueryData> Execute(ReservationUpdateRequest request, Guid userId);
}