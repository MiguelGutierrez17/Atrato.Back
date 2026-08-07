namespace Atrato.Entities.DTO.Rol;

public class RolQueryData
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool State { get; set; }
    public Guid EnterpriseId { get; set; }
    public string Enterprise { get; set; }
}