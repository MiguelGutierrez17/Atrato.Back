using Atrato.Entities.DTO.Address;

namespace Atrato.Commands.AddressCommands.Create;

public interface IAddressCreateCommand
{
    Task<AddressQueryData> Execute(AddressCreateRequest request, Guid userId);
}