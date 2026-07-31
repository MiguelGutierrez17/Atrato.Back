using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrato.Entities.Documents;

public class NotificationAudit
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Guid EntityTypeId { get; set; }
    public Guid Receipter { get; set; }
    public string EmailSender { get; set; }
    public string EmailReceipter { get; set; }
    public string Description { get; set; }
    public bool isEmail { get; set; }
    public bool Read { get; set; }
    public bool State { get; set; }
    public Guid EnterpriseId { get; set; }
    public Guid ItemId { get; set; }
    public Guid UserChange { get; set; }
    public DateTime DateChange { get; set; }
    public int AuditAction { get; set; }
}