namespace Atrato.Entities.DTO.Reservation;

public class ReservationQueryData
{
    public Guid Id { get; set; }
    public Guid ReservationStateId { get; set; }
    public string ReservationState { get; set; }
    public Guid ReservationTypeId { get; set; }
    public string ReservationType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid WorkStationId { get; set; }
    public string WorkStation { get; set; }
    public bool CancelByExpireTime { get; set; }
    public Guid UserId { get; set; }
    public string User { get; set; }
    public DateTime? CheckInDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid IdempotencyId { get; set; }
}