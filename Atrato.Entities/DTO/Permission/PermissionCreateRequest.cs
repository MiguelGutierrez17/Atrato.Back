namespace Atrato.Entities.DTO.Permission;

public class PermissionCreateRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool State { get; set; }
}
