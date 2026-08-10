using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.AddressAudit;

namespace Atrato.Commands.AddressAuditCommands.Create;

public class AddressAuditCreateCommand : IAddressAuditCreateCommand
{
    private readonly AtratoAuditContext _auditContext;

    public AddressAuditCreateCommand(AtratoAuditContext auditContext)
    {
        _auditContext = auditContext;
    }

    public Task Execute(AddressAuditCreateRequest request)
    {
        AddressAudit doc = new()
        {
            AuditAction = request.AuditAction,
            DateChange = request.DateChange,
            EnterpriseId = request.EnterpriseId,
            ItemId = request.ItemId,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            Route = request.Route,
            State = request.State,
            UserChange = request.UserChange,
            ValidationRadiusMeters = request.ValidationRadiusMeters,
        };

        _auditContext.Add(doc);

        return Task.CompletedTask;
    }
}