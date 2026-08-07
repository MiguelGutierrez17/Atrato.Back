using Atrato.Commands.FileDbCommands.Create;
using Atrato.Commands.FileDbCommands.Update;
using Atrato.Entities.DTO.FileDb;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.FileDbQueryObject;

namespace Atrato.Services.FileDbService;

public class FileDbService : IFileDbService
{
    private readonly IFileDbCreateCommand _createCommand;
    private readonly IFileDbUpdateCommand _updateCommand;
    private readonly IFileDbQueryObject _queryObject;

    public FileDbService(
        IFileDbCreateCommand createCommand,
        IFileDbUpdateCommand updateCommand,
        IFileDbQueryObject queryObject)
    {
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<FileDbQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.GetAll(cancellationToken);

        return new StandardResult<List<FileDbQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<FileDbQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<FileDbQueryData?>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<FileDbQueryData>> Post(FileDbCreateRequest request, Guid userId)
    {
        var response = await _createCommand.Execute(request, userId);

        return new StandardResult<FileDbQueryData>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<FileDbQueryData>> Put(FileDbUpdateRequest request, Guid userId)
    {
        var response = await _updateCommand.Execute(request, userId);

        return new StandardResult<FileDbQueryData>()
        {
            Success = true,
            Data = response
        };
    }
}
