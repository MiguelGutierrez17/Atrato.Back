using Atrato.Entities.DTO.Address;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.AddressService;

public interface IAddressService
{
    Task<StandardResult<List<AddressQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<AddressQueryData?>> ById(Guid id, CancellationToken cancellationToken);
    Task<StandardResult<List<AddressQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken);
    Task<StandardResult<AddressQueryData>> Post(AddressCreateRequest request, Guid userId);
    Task<StandardResult<AddressQueryData>> Put(AddressUpdateRequest request, Guid userId);
}