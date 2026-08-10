using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.NewsAudit;

namespace Atrato.Commands.NewsAuditCommands.Create;

public class NewsAuditCreateCommand : INewsAuditCreateCommand
{
    private readonly AtratoAuditContext _auditContext;

    public NewsAuditCreateCommand(AtratoAuditContext auditContext)
    {
        _auditContext = auditContext;
    }

    public Task Execute(NewsAuditCreateRequest request)
    {
        NewsAudit doc = new()
        {
            AuditAction = request.AuditAction,
            Body = request.Body,
            DateChange = request.DateChange,
            EndDate = request.EndDate,
            EnterpriseId = request.EnterpriseId,
            FileId = request.FileId,
            ItemId = request.ItemId,
            StartDate = request.StartDate,
            State = request.State,
            Title = request.Title,
            UserChange = request.UserChange,
        };

        _auditContext.Add(doc);

        return Task.CompletedTask;
    }
}