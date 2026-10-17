using Atrato.Entities.DTO.ReservationType;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.ReservationTypeQueryObject;

namespace Atrato.Services.ReservationTypeService;

public class ReservationTypeService : IReservationTypeService
{
    private readonly IReservationTypeQueryObject _queryObject;

    public ReservationTypeService(IReservationTypeQueryObject queryObject)
    {
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<ReservationTypeQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().GetAll(cancellationToken);

        return new StandardResult<List<ReservationTypeQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<ReservationTypeQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<ReservationTypeQueryData?>()
        {
            Success = true,
            Data = response
        };
    }
}
