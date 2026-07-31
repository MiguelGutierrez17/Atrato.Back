using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrato.Entities.Documents;

public class City
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    [Required]
    public Guid CountryId { get; set; }
    [ForeignKey(nameof(CountryId))]
    public Country Country { get; set; }
    public ICollection<Enterprise> Enterprise { get; set; } = new List<Enterprise>();
}