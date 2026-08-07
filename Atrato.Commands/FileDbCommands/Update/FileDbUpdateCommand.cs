using Atrato.Commands.FileDbAuditCommands.Create;
using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.FileDb;
using Atrato.Entities.Extensions;
using Atrato.Entities.SupportDTO;

namespace Atrato.Commands.FileDbCommands.Update;

public class FileDbUpdateCommand : IFileDbUpdateCommand
{
    private readonly AtratoContext _context;
    private readonly IFileDbAuditCreateCommand _auditCreateCommand;

    public FileDbUpdateCommand(AtratoContext context, IFileDbAuditCreateCommand auditCreateCommand)
    {
        _context = context;
        _auditCreateCommand = auditCreateCommand;
    }

    public async Task<FileDbQueryData> Execute(FileDbUpdateRequest request, Guid userId)
    {
        FileDb doc = new()
        {
            Id = request.Id,
            DateUpload = request.DateUpload,
            Extension = request.Extension,
            Name = request.Name,
            State = request.State,
            StorageId = request.StorageId,
            TypeFile = request.TypeFile,
            UserId = request.UserId,
        };

        _context.Update(doc);
        await _context.SaveChangesAsync();

        await _auditCreateCommand.Execute(doc.CastToAuditRequest(AuditAction.Update, userId));

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