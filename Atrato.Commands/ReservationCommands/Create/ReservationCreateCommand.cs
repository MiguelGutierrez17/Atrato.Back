using Atrato.Commands.ReservationAuditCommands.Create;
using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Reservation;
using Atrato.Entities.Extensions;
using Atrato.Entities.SupportDTO;

namespace Atrato.Commands.ReservationCommands.Create;

public class ReservationCreateCommand : IReservationCreateCommand
{
    private readonly AtratoContext _context;
    private readonly IReservationAuditCreateCommand _auditCreateCommand;

    public ReservationCreateCommand(AtratoContext context, IReservationAuditCreateCommand auditCreateCommand)
    {
        _context = context;
        _auditCreateCommand = auditCreateCommand;
    }

    public async Task<ReservationQueryData> Execute(ReservationCreateRequest request, Guid userId)
    {
        var now = DateTime.UtcNow;

        Reservation doc = new()
        {
            CancelByExpireTime = request.CancelByExpireTime,
            CheckInDate = request.CheckInDate,
            CheckOutDate = request.CheckOutDate,
            CreatedAt = now,
            EndDate = request.EndDate,
            IdempotencyId = request.IdempotencyId,
            ReservationStateId = request.ReservationStateId,
            ReservationTypeId = request.ReservationTypeId,
            StartDate = request.StartDate,
            UpdatedAt = now,
            UserId = request.UserId,
            WorkStationId = request.WorkStationId,
        };

        _context.Add(doc);
        await _context.SaveChangesAsync();

        await _auditCreateCommand.Execute(doc.CastToAuditRequest(AuditAction.Create, userId));

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