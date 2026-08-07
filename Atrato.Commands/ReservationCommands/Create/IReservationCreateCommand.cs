using Atrato.Entities.DTO.Reservation;

namespace Atrato.Commands.ReservationCommands.Create;

public interface IReservationCreateCommand
{
    Task<ReservationQueryData> Execute(ReservationCreateRequest request, Guid userId);
}