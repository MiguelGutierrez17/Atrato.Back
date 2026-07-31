using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrato.Entities.Documents;

public class UserAction
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    public ICollection<ChangeHistory> ChangesHistory { get; set; } = new List<ChangeHistory>();
}