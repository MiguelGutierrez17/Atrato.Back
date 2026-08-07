using Atrato.Entities.DTO.TimeZoneData;

namespace Atrato.QueryObjects.TimeZoneDataQueryObject;

public interface ITimeZoneDataQueryObject
{
    ITimeZoneDataQueryObject Clear();
    ITimeZoneDataQueryObject ForId(Guid id);
    Task<List<TimeZoneDataQueryData>> GetAll(CancellationToken cancellationToken);
    Task<TimeZoneDataQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}
