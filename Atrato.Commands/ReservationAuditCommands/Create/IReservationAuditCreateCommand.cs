using Atrato.Entities.DTO.ReservationAudit;

namespace Atrato.Commands.ReservationAuditCommands.Create;

public interface IReservationAuditCreateCommand
{
    Task Execute(ReservationAuditCreateRequest request);
}