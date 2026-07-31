namespace Atrato.Entities.DTO.Enterprise;

public class EnterpriseQueryData
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Identification { get; set; }
    public string? Phone { get; set; }
    public string Email { get; set; }
    public string? Picture { get; set; }
    public Guid CityId { get; set; }
    public string City { get; set; }
    public Guid TimeZoneId { get; set; }
    public string TimeZone { get; set; }
    public DateTime ShiftStart { get; set; }
    public DateTime ShiftEnd { get; set; }
    public bool State { get; set; }
}