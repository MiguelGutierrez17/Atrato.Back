using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Permission;

namespace Atrato.Commands.PermissionCommands.Create;

public class PermissionCreateCommand : IPermissionCreateCommand
{
    private readonly AtratoContext _context;

    public PermissionCreateCommand(AtratoContext context)
    {
        _context = context;
    }

    public async Task<PermissionQueryData> Execute(PermissionCreateRequest request, Guid userId)
    {
        Permission doc = new()
        {
            Description = request.Description,
            Name = request.Name,
            State = request.State,
        };

        _context.Add(doc);
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
