using Atrato.Commands.NewsAuditCommands.Create;
using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.News;
using Atrato.Entities.Extensions;
using Atrato.Entities.SupportDTO;

namespace Atrato.Commands.NewsCommands.Update;

public class NewsUpdateCommand : INewsUpdateCommand
{
    private readonly AtratoContext _context;
    private readonly INewsAuditCreateCommand _auditCreateCommand;

    public NewsUpdateCommand(AtratoContext context, INewsAuditCreateCommand auditCreateCommand)
    {
        _context = context;
        _auditCreateCommand = auditCreateCommand;
    }

    public async Task<NewsQueryData> Execute(NewsUpdateRequest request, Guid userId)
    {
        News doc = new()
        {
            Id = request.Id,
            Body = request.Body,
            EndDate = request.EndDate,
            EnterpriseId = request.EnterpriseId,
            FileId = request.FileId,
            StartDate = request.StartDate,
            State = request.State,
            Title = request.Title,
        };

        _context.Update(doc);
        await _context.SaveChangesAsync();

        await _auditCreateCommand.Execute(doc.CastToAuditRequest(AuditAction.Update, userId));

        return new NewsQueryData()
        {
            Id = doc.Id,
            Body = doc.Body,
            EndDate = doc.EndDate,
            EnterpriseId = doc.EnterpriseId,
            FileId = doc.FileId,
            StartDate = doc.StartDate,
            State = doc.State,
            Title = doc.Title,
        };
    }
}