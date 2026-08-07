using Atrato.Entities.DTO.Address;

namespace Atrato.Commands.AddressCommands.Update;

public interface IAddressUpdateCommand
{
    Task<AddressQueryData> Execute(AddressUpdateRequest request, Guid userId);
}