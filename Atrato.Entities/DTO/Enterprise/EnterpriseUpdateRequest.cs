namespace Atrato.Entities.DTO.Enterprise;

public class EnterpriseUpdateRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Identification { get; set; }
    public string? Phone { get; set; }
    public string Email { get; set; }
    public string? Picture { get; set; }
    public Guid CityId { get; set; }
    public Guid TimeZoneId { get; set; }
    public int ShiftStart { get; set; }
    public int ShiftEnd { get; set; }
    public bool State { get; set; }
}