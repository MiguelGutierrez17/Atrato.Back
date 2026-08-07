using Atrato.Entities.DTO.Country;

namespace Atrato.QueryObjects.CountryQueryObject;

public interface ICountryQueryObject
{
    ICountryQueryObject Clear();
    ICountryQueryObject ForId(Guid id);
    Task<List<CountryQueryData>> GetAll(CancellationToken cancellationToken);
    Task<CountryQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}
