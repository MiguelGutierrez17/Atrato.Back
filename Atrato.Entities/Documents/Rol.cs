using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrato.Entities.Documents;

public class Rol
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(300)]
    public string Name { get; set; }
    [Required]
    [MaxLength(300)]
    public string Description { get; set; }
    [Required]
    public bool State { get; set; }
    [Required]
    public Guid EnterpriseId { get; set; }
    [ForeignKey(nameof(EnterpriseId))]
    public Enterprise Enterprise { get; set; }
    public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    public ICollection<WorkStation> WorkStations { get; set; } = new List<WorkStation>();
}