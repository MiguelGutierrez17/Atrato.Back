namespace Atrato.Entities.DTO.NotificationAudit;

public class NotificationAuditCreateRequest
{
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