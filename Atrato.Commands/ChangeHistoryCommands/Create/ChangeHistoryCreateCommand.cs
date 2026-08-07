using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.ChangeHistory;

namespace Atrato.Commands.ChangeHistoryCommands.Create;

public class ChangeHistoryCreateCommand : IChangeHistoryCreateCommand
{
    private readonly AtratoContext _context;

    public ChangeHistoryCreateCommand(AtratoContext context)
    {
        _context = context;
    }

    public async Task<ChangeHistoryQueryData> Execute(ChangeHistoryCreateRequest request, Guid userId)
    {
        ChangeHistory doc = new()
        {
            ActionDate = request.ActionDate,
            ActionUser = request.ActionUser,
            EnterpriseId = request.EnterpriseId,
            EntityTypeId = request.EntityTypeId,
            ItemId = request.ItemId,
            NewValue = request.NewValue,
            PreviousValue = request.PreviousValue,
            UserActionId = request.UserActionId,
            ValueName = request.ValueName,
        };

        _context.Add(doc);
        await _context.SaveChangesAsync();

        return new ChangeHistoryQueryData()
        {
            Id = doc.Id,
            ActionDate = doc.ActionDate,
            ActionUser = doc.ActionUser,
            EnterpriseId = doc.EnterpriseId,
            EntityTypeId = doc.EntityTypeId,
            ItemId = doc.ItemId,
            NewValue = doc.NewValue,
            PreviousValue = doc.PreviousValue,
            UserActionId = doc.UserActionId,
            ValueName = doc.ValueName,
        };
    }
}
