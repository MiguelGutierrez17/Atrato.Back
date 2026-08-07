using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.ReservationAudit;

namespace Atrato.Commands.ReservationAuditCommands.Create;

public class ReservationAuditCreateCommand : IReservationAuditCreateCommand
{
    private readonly AtratoAuditContext _auditContext;

    public ReservationAuditCreateCommand(AtratoAuditContext auditContext)
    {
        _auditContext = auditContext;
    }

    public async Task Execute(ReservationAuditCreateRequest request)
    {
        ReservationAudit doc = new()
        {
            AuditAction = request.AuditAction,
            CancelByExpireTime = request.CancelByExpireTime,
            CheckInDate = request.CheckInDate,
            CheckOutDate = request.CheckOutDate,
            CreatedAt = request.CreatedAt,
            DateChange = request.DateChange,
            EndDate = request.EndDate,
            IdempotencyId = request.IdempotencyId,
            ItemId = request.ItemId,
            ReservationStateId = request.ReservationStateId,
            ReservationTypeId = request.ReservationTypeId,
            RowVersion = request.RowVersion,
            StartDate = request.StartDate,
            UpdatedAt = request.UpdatedAt,
            UserChange = request.UserChange,
            UserId = request.UserId,
            WorkStationId = request.WorkStationId,
        };

        _auditContext.Add(doc);
        await _auditContext.SaveChangesAsync();
    }
}