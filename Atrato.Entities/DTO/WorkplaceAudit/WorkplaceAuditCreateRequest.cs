namespace Atrato.Entities.DTO.WorkplaceAudit;

public class WorkplaceAuditCreateRequest
{
    public string Name { get; set; }
    public string Image { get; set; }
    public int? WaitTime { get; set; }
    public Guid EnterpriseId { get; set; }
    public bool State { get; set; }
    public Guid ItemId { get; set; }
    public Guid UserChange { get; set; }
    public DateTime DateChange { get; set; }
    public int AuditAction { get; set; }
}