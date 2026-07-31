using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrato.Entities.Documents;

public class Enterprise
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    [Required]
    [MaxLength(50)]
    public string Identification { get; set; }
    [MaxLength(30)]
    public string? Phone { get; set; }
    [Required]
    [MaxLength(30)]
    public string Email { get; set; }
    public string? Picture { get; set; }
    [Required]
    public Guid CityId { get; set; }
    [ForeignKey("CityId")]
    public City City { get; set; }
    [Required]
    public Guid TimeZoneId { get; set; }
    [ForeignKey(nameof(TimeZoneId))]
    public TimeZoneData TimeZoneData { get; set; }
    [Required]
    public DateTime ShiftStart { get; set; }
    [Required]
    public DateTime ShiftEnd { get; set; }
    [Required]
    public bool State { get; set; }
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
    public ICollection<Area> Areas { get; set; } = new List<Area>();
    public ICollection<UserEnterprise> UserEnterprises { get; set; } = new List<UserEnterprise>();
    public ICollection<Rol> Roles { get; set; } = new List<Rol>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    public ICollection<Workplace> Workplaces { get; set; } = new List<Workplace>();
    public ICollection<News> News { get; set; } = new List<News>();
}