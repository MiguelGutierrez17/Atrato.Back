namespace Atrato.Entities.DTO.Workplace;

public class WorkplaceUpdateRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public int? WaitTime { get; set; }
    public Guid EnterpriseId { get; set; }
    public bool State { get; set; }
}