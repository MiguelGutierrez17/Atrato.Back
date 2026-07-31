using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrato.Entities.Documents;

public class Address
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(300)]
    public string Route { get; set; }
    [Required]
    public int Latitude { get; set; }
    [Required]
    public int Longitude { get; set; }
    [Required]
    public int ValidationRadiusMeters { get; set; }
    [Required]
    public bool State { get; set; }
    [Required]
    public Guid EnterpriseId { get; set; }
    [ForeignKey(nameof(EnterpriseId))]
    public Enterprise Enterprise { get; set; }
}