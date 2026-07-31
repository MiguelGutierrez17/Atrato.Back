using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atrato.Entities.Documents;

[Index(nameof(IdempotencyId), IsUnique = true)]
[Index(nameof(WorkStationId), nameof(StartDate), nameof(EndDate))]
public class Reservation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    public Guid ReservationStateId { get; set; }
    [ForeignKey("ReservationStateId")]
    public ReservationState ReservationState { get; set; }
    [Required]
    public Guid ReservationTypeId { get; set; }
    [ForeignKey("ReservationTypeId")]
    public ReservationType ReservationType { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    [Required]
    public Guid WorkStationId { get; set; }
    [Required]
    public bool CancelByExpireTime { get; set; }
    [Required]
    public Guid UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }
    public DateTime? CheckInDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public DateTime UpdatedAt { get; set; }
    [Required]
    public Guid IdempotencyId { get; set; }
}