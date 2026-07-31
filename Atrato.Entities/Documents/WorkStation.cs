using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrato.Entities.Documents;

public class WorkStation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    [Required]
    public Guid WorkplaceId { get; set; }
    [ForeignKey(nameof(WorkplaceId))]
    public Workplace Workplace { get; set; }
    [Required]
    public Guid WorkStationStateId { get; set; }
    [ForeignKey(nameof(WorkStationStateId))]
    public WorkStationState WorkStationState { get; set; }
    [Required]
    public Guid OwnerArea { get; set; }
    [ForeignKey(nameof(OwnerArea))]
    public Area OwnerAreaNavigation { get; set; }
    [Required]
    public int PositionX { get; set; }
    [Required]
    public int PositionY { get; set; }
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<Rol> Roles { get; set; } = new List<Rol>();
}