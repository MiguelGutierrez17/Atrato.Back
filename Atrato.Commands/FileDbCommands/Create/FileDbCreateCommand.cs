using Atrato.Commands.FileDbAuditCommands.Create;
using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.FileDb;
using Atrato.Entities.Extensions;
using Atrato.Entities.SupportDTO;

namespace Atrato.Commands.FileDbCommands.Create;

public class FileDbCreateCommand : IFileDbCreateCommand
{
    private readonly AtratoContext _context;
    private readonly IFileDbAuditCreateCommand _auditCreateCommand;

    public FileDbCreateCommand(AtratoContext context, IFileDbAuditCreateCommand auditCreateCommand)
    {
        _context = context;
        _auditCreateCommand = auditCreateCommand;
    }

    public async Task<FileDbQueryData> Execute(FileDbCreateRequest request, Guid userId)
    {
        FileDb doc = new()
        {
            DateUpload = request.DateUpload,
            Extension = request.Extension,
            Name = request.Name,
            State = request.State,
            StorageId = request.StorageId,
            TypeFile = request.TypeFile,
            UserId = request.UserId,
        };

        _context.Add(doc);
        await _context.SaveChangesAsync();

        await _auditCreateCommand.Execute(doc.CastToAuditRequest(AuditAction.Create, userId));

        return new FileDbQueryData()
        {
            Id = doc.Id,
            DateUpload = doc.DateUpload,
            Extension = doc.Extension,
            Name = doc.Name,
            State = doc.State,
            StorageId = doc.StorageId,
            TypeFile = doc.TypeFile,
            UserId = doc.UserId,
        };
    }
}