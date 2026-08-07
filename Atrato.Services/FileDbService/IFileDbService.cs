using Atrato.Entities.DTO.FileDb;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.FileDbService;

public interface IFileDbService
{
    Task<StandardResult<List<FileDbQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<FileDbQueryData?>> ById(Guid id, CancellationToken cancellationToken);
    Task<StandardResult<FileDbQueryData>> Post(FileDbCreateRequest request, Guid userId);
    Task<StandardResult<FileDbQueryData>> Put(FileDbUpdateRequest request, Guid userId);
}
