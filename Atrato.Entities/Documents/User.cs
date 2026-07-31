using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrato.Entities.Documents;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    [Required]
    [MaxLength(2)]
    public string Initials { get; set; }
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }
    [MaxLength(30)]
    public string Phone { get; set; }
    [Required]
    public bool State { get; set; }
    [Required]
    public bool isSuperAdmin { get; set; }
    public ICollection<Area> Areas { get; set; } = new List<Area>();
    public ICollection<UserEnterprise> UserEnterprises { get; set; } = new List<UserEnterprise>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    public ICollection<ErrorHistory> ErrorsHistory { get; set; } = new List<ErrorHistory>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    public ICollection<Invitation> Invitations { get; set; } = new List<Invitation>();
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    public ICollection<WorkStation> WorkStations { get; set; } = new List<WorkStation>();
}