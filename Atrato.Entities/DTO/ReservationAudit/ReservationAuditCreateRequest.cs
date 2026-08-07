namespace Atrato.Entities.DTO.ReservationAudit;

public class ReservationAuditCreateRequest
{
    public Guid ReservationStateId { get; set; }
    public Guid ReservationTypeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid WorkStationId { get; set; }
    public bool CancelByExpireTime { get; set; }
    public Guid UserId { get; set; }
    public byte[] RowVersion { get; set; }
    public DateTime? CheckInDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid IdempotencyId { get; set; }
    public Guid ItemId { get; set; }
    public Guid UserChange { get; set; }
    public DateTime DateChange { get; set; }
    public int AuditAction { get; set; }
}