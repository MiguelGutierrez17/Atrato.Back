namespace Atrato.Entities.DTO.Area;

public class AreaCreateRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool State { get; set; }
    public Guid EnterpriseId { get; set; }
}
