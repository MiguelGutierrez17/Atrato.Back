using Atrato.Entities.DTO.FileDb;

namespace Atrato.QueryObjects.FileDbQueryObject;

public interface IFileDbQueryObject
{
    IFileDbQueryObject Clear();
    IFileDbQueryObject ForId(Guid id);
    IFileDbQueryObject ForIds(List<Guid> ids);
    IFileDbQueryObject ForState(bool state);
    IFileDbQueryObject ForUser(Guid userId);
    Task<List<FileDbQueryData>> GetAll(CancellationToken cancellationToken);
    Task<FileDbQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}
