using Atrato.Entities.DTO.Guide;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.GuideQueryObject;

namespace Atrato.Services.GuideService;

public class GuideService : IGuideService
{
    private readonly IGuideQueryObject _queryObject;

    public GuideService(IGuideQueryObject queryObject)
    {
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<GuideQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.GetAll(cancellationToken);

        return new StandardResult<List<GuideQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<GuideQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<GuideQueryData?>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<List<GuideQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForEnterprise(enterpriseId).GetAll(cancellationToken);

        return new StandardResult<List<GuideQueryData>>()
        {
            Success = true,
            Data = response
        };
    }
}
