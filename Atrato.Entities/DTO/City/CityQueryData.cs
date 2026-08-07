namespace Atrato.Entities.DTO.City;

public class CityQueryData
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CountryId { get; set; }
    public string Country { get; set; }
}
