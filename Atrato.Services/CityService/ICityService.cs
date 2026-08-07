using Atrato.Entities.DTO.City;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.CityService;

public interface ICityService
{
    Task<StandardResult<List<CityQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<CityQueryData?>> ById(Guid id, CancellationToken cancellationToken);
    Task<StandardResult<List<CityQueryData>>> ByCountry(Guid countryId, CancellationToken cancellationToken);
}
