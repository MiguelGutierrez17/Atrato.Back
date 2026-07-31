using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.ErrorHistory;

namespace Atrato.Commands.ErrorHistoryCommands.Create;

public class ErrorHistoryCreateCommand : IErrorHistoryCreateCommand
{
    private readonly AtratoContext _context;

    public ErrorHistoryCreateCommand(AtratoContext context)
    {
        _context = context;
    }

    public async Task<ErrorHistoryQueryData> Execute(ErrorHistoryCreateRequest request, Guid userId)
    {
        ErrorHistory doc = new()
        {
            UserId = userId,
            CreatedAt = DateTime.UtcNow,
            Message = request.Message,
            Method = request.Method,
            Path = request.Path,
            Payload = request.Payload,
            StackTrace = request.StackTrace,
        };

        _context.Add(doc);
        await _context.SaveChangesAsync();

        return new ErrorHistoryQueryData()
        {
            Id = doc.Id,
            UserId = doc.UserId,
            CreatedAt = doc.CreatedAt,
            Message = doc.Message,
            Method = doc.Method,
            Path = doc.Path,
            Payload = doc.Payload,
            StackTrace = doc.StackTrace,
        };
    }
}