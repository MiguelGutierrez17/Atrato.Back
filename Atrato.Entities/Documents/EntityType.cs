using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Atrato.Entities.Documents;

public class EntityType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    public ICollection<ChangeHistory> ChangesHistory { get; set; } = new List<ChangeHistory>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}