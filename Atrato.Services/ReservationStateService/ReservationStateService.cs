using Atrato.Entities.DTO.ReservationState;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.ReservationStateQueryObject;

namespace Atrato.Services.ReservationStateService;

public class ReservationStateService : IReservationStateService
{
    private readonly IReservationStateQueryObject _queryObject;

    public ReservationStateService(IReservationStateQueryObject queryObject)
    {
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<ReservationStateQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().GetAll(cancellationToken);

        return new StandardResult<List<ReservationStateQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<ReservationStateQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<ReservationStateQueryData?>()
        {
            Success = true,
            Data = response
        };
    }
}
