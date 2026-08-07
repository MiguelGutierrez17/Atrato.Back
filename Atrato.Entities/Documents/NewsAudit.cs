using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace Atrato.Entities.Documents;

public class NewsAudit
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Body { get; set; }
    public Guid? FileId { get; set; }
    public bool State { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid EnterpriseId { get; set; }
    public Guid ItemId { get; set; }
    public Guid UserChange { get; set; }
    public DateTime DateChange { get; set; }
    public int AuditAction { get; set; }
}