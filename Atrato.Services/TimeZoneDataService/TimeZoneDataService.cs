using Atrato.Entities.DTO.TimeZoneData;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.TimeZoneDataQueryObject;

namespace Atrato.Services.TimeZoneDataService;

public class TimeZoneDataService : ITimeZoneDataService
{
    private readonly ITimeZoneDataQueryObject _queryObject;

    public TimeZoneDataService(ITimeZoneDataQueryObject queryObject)
    {
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<TimeZoneDataQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().GetAll(cancellationToken);

        return new StandardResult<List<TimeZoneDataQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<TimeZoneDataQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<TimeZoneDataQueryData?>()
        {
            Success = true,
            Data = response
        };
    }
}
