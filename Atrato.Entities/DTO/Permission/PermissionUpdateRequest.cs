namespace Atrato.Entities.DTO.Permission;

public class PermissionUpdateRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool State { get; set; }
}
