namespace Atrato.Entities.DTO.NewsAudit;

public class NewsAuditCreateRequest
{
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