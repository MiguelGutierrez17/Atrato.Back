using Atrato.Entities.DTO.Guide;

namespace Atrato.QueryObjects.GuideQueryObject;

public interface IGuideQueryObject
{
    IGuideQueryObject Clear();
    IGuideQueryObject ForId(Guid id);
    IGuideQueryObject ForState(bool state);
    IGuideQueryObject ForEnterprise(Guid enterpriseId);
    IGuideQueryObject ForFile(Guid fileId);
    Task<List<GuideQueryData>> GetAll(CancellationToken cancellationToken);
    Task<GuideQueryData?> FirstOrDefault(CancellationToken cancellationToken);
}
