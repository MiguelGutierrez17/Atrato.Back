namespace Atrato.Entities.DTO.WorkStationAudit;

public class WorkStationAuditCreateRequest
{
    public string Name { get; set; }
    public Guid WorkplaceId { get; set; }
    public Guid WorkStationStateId { get; set; }
    public Guid OwnerArea { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public Guid ItemId { get; set; }
    public Guid UserChange { get; set; }
    public DateTime DateChange { get; set; }
    public int AuditAction { get; set; }
}