using Atrato.Entities.DTO.AddressAudit;

namespace Atrato.Commands.AddressAuditCommands.Create;

public interface IAddressAuditCreateCommand
{
    Task Execute(AddressAuditCreateRequest request);
}