using Atrato.Entities.DTO.City;

namespace Atrato.QueryObjects.CityQueryObject;

public interface ICityQueryObject
{
    ICityQueryObject Clear();
    ICityQueryObject ForId(Guid id);
    ICityQueryObject ForCountry(Guid countryId);
    Task<List<CityQueryData>> GetAll(CancellationToken cancellationToken);
    Task<CityQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}
