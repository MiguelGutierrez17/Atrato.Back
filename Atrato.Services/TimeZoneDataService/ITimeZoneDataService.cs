using Atrato.Entities.DTO.TimeZoneData;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.TimeZoneDataService;

public interface ITimeZoneDataService
{
    Task<StandardResult<List<TimeZoneDataQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<TimeZoneDataQueryData?>> ById(Guid id, CancellationToken cancellationToken);
}
