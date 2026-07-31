using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrato.Entities.Documents;

public class Area
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [MaxLength(200)]
    public string Description { get; set; }
    [Required]
    public bool State { get; set; }
    [Required]
    public Guid EnterpriseId { get; set; }
    [ForeignKey(nameof(EnterpriseId))]
    public Enterprise Enterprise { get; set; }
    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<WorkStation> WorkStations { get; set; } = new List<WorkStation>();
}