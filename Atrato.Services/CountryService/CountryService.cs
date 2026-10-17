using Atrato.Entities.DTO.Country;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.CountryQueryObject;

namespace Atrato.Services.CountryService;

public class CountryService : ICountryService
{
    private readonly ICountryQueryObject _queryObject;

    public CountryService(ICountryQueryObject queryObject)
    {
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<CountryQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().GetAll(cancellationToken);

        return new StandardResult<List<CountryQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<CountryQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<CountryQueryData?>()
        {
            Success = true,
            Data = response
        };
    }
}
