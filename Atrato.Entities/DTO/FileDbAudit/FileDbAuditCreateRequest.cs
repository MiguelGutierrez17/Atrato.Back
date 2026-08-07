namespace Atrato.Entities.DTO.FileDbAudit;

public class FileDbAuditCreateRequest
{
    public string Name { get; set; }
    public string Extension { get; set; }
    public DateTime DateUpload { get; set; }
    public string TypeFile { get; set; }
    public Guid StorageId { get; set; }
    public Guid UserId { get; set; }
    public bool State { get; set; }
    public Guid ItemId { get; set; }
    public Guid UserChange { get; set; }
    public DateTime DateChange { get; set; }
    public int AuditAction { get; set; }
}