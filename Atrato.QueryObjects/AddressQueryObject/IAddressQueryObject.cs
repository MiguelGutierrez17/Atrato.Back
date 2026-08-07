using Atrato.Entities.DTO.Address;

namespace Atrato.QueryObjects.AddressQueryObject;

public interface IAddressQueryObject
{
    IAddressQueryObject Clear();
    IAddressQueryObject ForId(Guid id);
    IAddressQueryObject ForState(bool state);
    IAddressQueryObject ForEnterprise(Guid enterpriseId);
    Task<List<AddressQueryData>> GetAll(CancellationToken cancellationToken);
    Task<AddressQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}