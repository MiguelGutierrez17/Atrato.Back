using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrato.Entities.Documents;

public class Permission
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(300)]
    public string Name { get; set; }
    [Required]
    [MaxLength(300)]
    public string Description { get; set; }
    [Required]
    public bool State { get; set; }
    public ICollection<Rol> Rols { get; set; } = new List<Rol>();
}