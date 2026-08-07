namespace Atrato.Entities.DTO.Rol;

public class RolCreateRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool State { get; set; }
    public Guid EnterpriseId { get; set; }
}