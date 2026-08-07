using Atrato.Entities.DTO.UserAction;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.UserActionService;

public interface IUserActionService
{
    Task<StandardResult<List<UserActionQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<UserActionQueryData?>> ById(Guid id, CancellationToken cancellationToken);
}
