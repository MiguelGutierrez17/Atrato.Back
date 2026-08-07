namespace Atrato.Entities.DTO.Address;

public class AddressCreateRequest
{
    public string Route { get; set; }
    public int Latitude { get; set; }
    public int Longitude { get; set; }
    public int ValidationRadiusMeters { get; set; }
    public bool State { get; set; }
    public Guid EnterpriseId { get; set; }
}