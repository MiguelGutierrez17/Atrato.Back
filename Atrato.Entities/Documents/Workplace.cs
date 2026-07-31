using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrato.Entities.Documents;

public class Workplace
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    public string Image { get; set; }
    public int? WaitTime { get; set; }
    [Required]
    public Guid EnterpriseId { get; set; }
    [ForeignKey("EnterpriseId")]
    public Enterprise Enterprise { get; set; }
    [Required]
    public bool State { get; set; }
    public ICollection<WorkStation> WorkStations { get; set; } = new List<WorkStation>();
}