namespace Atrato.Entities.DTO.Reservation;

public class ReservationCreateRequest
{
    public Guid ReservationStateId { get; set; }
    public Guid ReservationTypeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid WorkStationId { get; set; }
    public bool CancelByExpireTime { get; set; }
    public Guid UserId { get; set; }
    public DateTime? CheckInDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    public Guid IdempotencyId { get; set; }
}