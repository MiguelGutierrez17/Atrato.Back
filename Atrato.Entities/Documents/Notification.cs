using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrato.Entities.Documents;

public class Notification
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public Guid EntityTypeId { get; set; }
    [ForeignKey(nameof(EntityTypeId))]
    public EntityType EntityType { get; set; }
    [Required]
    public Guid Receipter { get; set; }
    [ForeignKey(nameof(Receipter))]
    public User User { get; set; }
    [Required]
    [MaxLength(100)]
    public string EmailSender { get; set; }
    [Required]
    [MaxLength(100)]
    public string EmailReceipter { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public bool isEmail { get; set; }
    [Required]
    public bool Read { get; set; }
    [Required]
    public bool State { get; set; }
    [Required]
    public Guid EnterpriseId { get; set; }
    [ForeignKey(nameof(EnterpriseId))]
    public Enterprise Enterprise { get; set; }
}