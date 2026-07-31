namespace Atrato.Entities.DTO.Enterprise;

public class EnterpriseCreateRequest
{
    public string Name { get; set; }
    public string Identification { get; set; }
    public string? Phone { get; set; }
    public string Email { get; set; }
    public string? Picture { get; set; }
    public Guid CityId { get; set; }
    public Guid TimeZoneId { get; set; }
    public DateTime ShiftStart { get; set; }
    public DateTime ShiftEnd { get; set; }
    public bool State { get; set; }
}