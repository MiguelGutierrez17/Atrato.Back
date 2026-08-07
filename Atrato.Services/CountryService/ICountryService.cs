using Atrato.Entities.DTO.Country;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.CountryService;

public interface ICountryService
{
    Task<StandardResult<List<CountryQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<CountryQueryData?>> ById(Guid id, CancellationToken cancellationToken);
}
