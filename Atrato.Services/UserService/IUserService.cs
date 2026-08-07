using Atrato.Entities.DTO.User;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.UserService;

public interface IUserService
{
    Task<StandardResult<List<UserQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<UserQueryData?>> ById(Guid id, CancellationToken cancellationToken);
    Task<StandardResult<List<UserQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken);
    Task<StandardResult<UserQueryData>> Post(UserCreateRequest request, Guid userId);
    Task<StandardResult<UserQueryData>> Put(UserUpdateRequest request, Guid userId);
}
