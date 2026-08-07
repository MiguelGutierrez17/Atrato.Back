using Atrato.Entities.DTO.City;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.CityQueryObject;

namespace Atrato.Services.CityService;

public class CityService : ICityService
{
    private readonly ICityQueryObject _queryObject;

    public CityService(ICityQueryObject queryObject)
    {
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<CityQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.GetAll(cancellationToken);

        return new StandardResult<List<CityQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<CityQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<CityQueryData?>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<List<CityQueryData>>> ByCountry(Guid countryId, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForCountry(countryId).GetAll(cancellationToken);

        return new StandardResult<List<CityQueryData>>()
        {
            Success = true,
            Data = response
        };
    }
}
