using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.FileDbAudit;

namespace Atrato.Commands.FileDbAuditCommands.Create;

public class FileDbAuditCreateCommand : IFileDbAuditCreateCommand
{
    private readonly AtratoAuditContext _auditContext;

    public FileDbAuditCreateCommand(AtratoAuditContext auditContext)
    {
        _auditContext = auditContext;
    }

    public Task Execute(FileDbAuditCreateRequest request)
    {
        FileDbAudit doc = new()
        {
            AuditAction = request.AuditAction,
            DateChange = request.DateChange,
            DateUpload = request.DateUpload,
            Extension = request.Extension,
            ItemId = request.ItemId,
            Name = request.Name,
            State = request.State,
            StorageId = request.StorageId,
            TypeFile = request.TypeFile,
            UserChange = request.UserChange,
            UserId = request.UserId,
        };

        _auditContext.Add(doc);

        return Task.CompletedTask;
    }
}