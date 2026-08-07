using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Permission;

namespace Atrato.Commands.PermissionCommands.Update;

public class PermissionUpdateCommand : IPermissionUpdateCommand
{
    private readonly AtratoContext _context;

    public PermissionUpdateCommand(AtratoContext context)
    {
        _context = context;
    }

    public async Task<PermissionQueryData> Execute(PermissionUpdateRequest request, Guid userId)
    {
        Permission doc = new()
        {
            Id = request.Id,
            Description = request.Description,
            Name = request.Name,
            State = request.State,
        };

        _context.Update(doc);
        await _context.SaveChangesAsync();

        return new PermissionQueryData()
        {
            Id = doc.Id,
            Description = doc.Description,
            Name = doc.Name,
            State = doc.State,
        };
    }
}
