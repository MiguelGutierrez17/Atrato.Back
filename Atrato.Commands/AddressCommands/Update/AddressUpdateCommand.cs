using Atrato.Commands.AddressAuditCommands.Create;
using Atrato.Entities.Context;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Address;
using Atrato.Entities.Extensions;
using Atrato.Entities.SupportDTO;

namespace Atrato.Commands.AddressCommands.Update;

public class AddressUpdateCommand : IAddressUpdateCommand
{
    private readonly AtratoContext _context;
    private readonly IAddressAuditCreateCommand _auditCreateCommand;

    public AddressUpdateCommand(AtratoContext context, IAddressAuditCreateCommand auditCreateCommand)
    {
        _context = context;
        _auditCreateCommand = auditCreateCommand;
    }

    public async Task<AddressQueryData> Execute(AddressUpdateRequest request, Guid userId)
    {
        Address doc = new()
        {
            Id = request.Id,
            EnterpriseId = request.EnterpriseId,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            Route = request.Route,
            State = request.State,
            ValidationRadiusMeters = request.ValidationRadiusMeters,
        };

        _context.Update(doc);
        await _context.SaveChangesAsync();

        await _auditCreateCommand.Execute(doc.CastToAuditRequest(AuditAction.Update, userId));

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