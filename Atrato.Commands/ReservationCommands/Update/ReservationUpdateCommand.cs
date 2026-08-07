using Atrato.Commands.ReservationAuditCommands.Create;
using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Reservation;
using Atrato.Entities.Extensions;
using Atrato.Entities.SupportDTO;

namespace Atrato.Commands.ReservationCommands.Update;

public class ReservationUpdateCommand : IReservationUpdateCommand
{
    private readonly AtratoContext _context;
    private readonly IReservationAuditCreateCommand _auditCreateCommand;

    public ReservationUpdateCommand(AtratoContext context, IReservationAuditCreateCommand auditCreateCommand)
    {
        _context = context;
        _auditCreateCommand = auditCreateCommand;
    }

    public async Task<ReservationQueryData> Execute(ReservationUpdateRequest request, Guid userId)
    {
        Reservation doc = new()
        {
            Id = request.Id,
            CancelByExpireTime = request.CancelByExpireTime,
            CheckInDate = request.CheckInDate,
            CheckOutDate = request.CheckOutDate,
            EndDate = request.EndDate,
            IdempotencyId = request.IdempotencyId,
            ReservationStateId = request.ReservationStateId,
            ReservationTypeId = request.ReservationTypeId,
            StartDate = request.StartDate,
            UpdatedAt = DateTime.UtcNow,
            UserId = request.UserId,
            WorkStationId = request.WorkStationId,
        };

        _context.Update(doc);
        await _context.SaveChangesAsync();

        await _auditCreateCommand.Execute(doc.CastToAuditRequest(AuditAction.Update, userId));

        return new ReservationQueryData()
        {
            Id = doc.Id,
            CancelByExpireTime = doc.CancelByExpireTime,
            CheckInDate = doc.CheckInDate,
            CheckOutDate = doc.CheckOutDate,
            CreatedAt = doc.CreatedAt,
            EndDate = doc.EndDate,
            IdempotencyId = doc.IdempotencyId,
            ReservationStateId = doc.ReservationStateId,
            ReservationTypeId = doc.ReservationTypeId,
            StartDate = doc.StartDate,
            UpdatedAt = doc.UpdatedAt,
            UserId = doc.UserId,
            WorkStationId = doc.WorkStationId,
        };
    }
}