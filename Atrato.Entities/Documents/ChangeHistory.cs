using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrato.Entities.Documents;

public class ChangeHistory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    public Guid EntityTypeId { get; set; }
    [ForeignKey(nameof(EntityTypeId))]
    public EntityType EntityType { get; set; }
    [Required]
    public Guid ItemId { get; set; }
    [Required]
    public Guid UserActionId { get; set; }
    [ForeignKey(nameof(UserActionId))]
    public UserAction UserAction { get; set; }
    [Required]
    public string ValueName { get; set; }
    [Required]
    public string PreviousValue { get; set; }
    [Required]
    public string NewValue { get; set; }
    [Required]
    public Guid ActionUser { get; set; }
    [ForeignKey(nameof(ActionUser))]
    public User User { get; set; }
    [Required]
    public DateTime ActionDate { get; set; }
    [Required]
    public Guid EnterpriseId { get; set; }
    [ForeignKey(nameof(EnterpriseId))]
    public Enterprise Enterprise { get; set; }
}