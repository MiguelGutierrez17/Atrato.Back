using Atrato.Commands.AddressAuditCommands.Create;
using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Address;
using Atrato.Entities.Extensions;
using Atrato.Entities.SupportDTO;

namespace Atrato.Commands.AddressCommands.Create;

public class AddressCreateCommand : IAddressCreateCommand
{
    private readonly AtratoContext _context;
    private readonly IAddressAuditCreateCommand _auditCreateCommand;

    public AddressCreateCommand(AtratoContext context, IAddressAuditCreateCommand auditCreateCommand)
    {
        _context = context;
        _auditCreateCommand = auditCreateCommand;
    }

    public async Task<AddressQueryData> Execute(AddressCreateRequest request, Guid userId)
    {
        Address doc = new()
        {
            EnterpriseId = request.EnterpriseId,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            Route = request.Route,
            State = request.State,
            ValidationRadiusMeters = request.ValidationRadiusMeters,
        };

        _context.Add(doc);
        await _context.SaveChangesAsync();

        await _auditCreateCommand.Execute(doc.CastToAuditRequest(AuditAction.Create, userId));

        return new AddressQueryData()
        {
            Id = doc.Id,
            EnterpriseId = doc.EnterpriseId,
            Latitude = doc.Latitude,
            Longitude = doc.Longitude,
            Route = doc.Route,
            State = doc.State,
            ValidationRadiusMeters = doc.ValidationRadiusMeters,
        };
    }
}