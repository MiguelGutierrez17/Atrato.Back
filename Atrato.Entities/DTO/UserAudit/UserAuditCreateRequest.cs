namespace Atrato.Entities.DTO.UserAudit;

public class UserAuditCreateRequest
{
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