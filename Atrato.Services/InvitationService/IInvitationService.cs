using Atrato.Entities.DTO.Invitation;
using Atrato.Entities.SupportDTO;

namespace Atrato.Services.InvitationService;

public interface IInvitationService
{
    Task<StandardResult<List<InvitationQueryData>>> GetAll(CancellationToken cancellationToken);
    Task<StandardResult<InvitationQueryData?>> ById(Guid id, CancellationToken cancellationToken);
    Task<StandardResult<List<InvitationQueryData>>> ByUser(Guid userId, CancellationToken cancellationToken);
    Task<StandardResult<InvitationQueryData>> Post(InvitationCreateRequest request, Guid userId);
    Task<StandardResult<InvitationQueryData>> Put(InvitationUpdateRequest request, Guid userId);
}
