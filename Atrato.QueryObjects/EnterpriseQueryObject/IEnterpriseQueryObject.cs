using Atrato.Entities.DTO.Enterprise;

namespace Atrato.QueryObjects.EnterpriseQueryObject;

public interface IEnterpriseQueryObject
{
    IEnterpriseQueryObject Clear();
    IEnterpriseQueryObject ForId(Guid id);
    IEnterpriseQueryObject ForUser(Guid userId);
    Task<List<EnterpriseQueryData>> GetAll(CancellationToken cancellationToken);
    Task<EnterpriseQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}