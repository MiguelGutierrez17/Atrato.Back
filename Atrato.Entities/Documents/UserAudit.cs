using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrato.Entities.Documents;

public class UserAudit
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Initials { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool State { get; set; }
    public bool isSuperAdmin { get; set; }
    public Guid ItemId { get; set; }
    public Guid UserChange { get; set; }
    public DateTime DateChange { get; set; }
    public int AuditAction { get; set; }
}