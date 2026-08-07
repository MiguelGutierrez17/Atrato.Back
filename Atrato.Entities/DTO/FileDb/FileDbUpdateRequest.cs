namespace Atrato.Entities.DTO.FileDb;

public class FileDbUpdateRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Extension { get; set; }
    public DateTime DateUpload { get; set; }
    public string TypeFile { get; set; }
    public Guid StorageId { get; set; }
    public Guid UserId { get; set; }
    public bool State { get; set; }
}