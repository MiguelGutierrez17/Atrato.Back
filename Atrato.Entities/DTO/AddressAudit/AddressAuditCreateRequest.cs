namespace Atrato.Entities.DTO.AddressAudit;

public class AddressAuditCreateRequest
{
    public string Route { get; set; }
    public int Latitude { get; set; }
    public int Longitude { get; set; }
    public int ValidationRadiusMeters { get; set; }
    public bool State { get; set; }
    public Guid EnterpriseId { get; set; }
    public Guid ItemId { get; set; }
    public Guid UserChange { get; set; }
    public DateTime DateChange { get; set; }
    public int AuditAction { get; set; }
}