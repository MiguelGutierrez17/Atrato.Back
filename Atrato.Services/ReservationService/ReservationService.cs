using Atrato.Commands.ReservationCommands.Create;
using Atrato.Commands.ReservationCommands.Update;
using Atrato.Entities.DTO.Reservation;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.ReservationQueryObject;

namespace Atrato.Services.ReservationService;

public class ReservationService : IReservationService
{
    private readonly IReservationCreateCommand _createCommand;
    private readonly IReservationUpdateCommand _updateCommand;
    private readonly IReservationQueryObject _queryObject;

    public ReservationService(
        IReservationCreateCommand createCommand,
        IReservationUpdateCommand updateCommand,
        IReservationQueryObject queryObject)
    {
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<ReservationQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().GetAll(cancellationToken);

        return new StandardResult<List<ReservationQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<ReservationQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<ReservationQueryData?>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<List<ReservationQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForEnterprise(enterpriseId).GetAll(cancellationToken);

        return new StandardResult<List<ReservationQueryData>>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<List<ReservationQueryData>>> ByWorkplace(Guid workplaceId, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForWorkplace(workplaceId).GetAll(cancellationToken);

        return new StandardResult<List<ReservationQueryData>>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<List<ReservationQueryData>>> ByWorkStation(Guid workStationId, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForWorkStation(workStationId).GetAll(cancellationToken);

        return new StandardResult<List<ReservationQueryData>>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<List<ReservationQueryData>>> ByUser(Guid userId, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForUser(userId).GetAll(cancellationToken);

        return new StandardResult<List<ReservationQueryData>>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<ReservationQueryData>> Post(ReservationCreateRequest request, Guid userId)
    {
        var response = await _createCommand.Execute(request, userId);

        return new StandardResult<ReservationQueryData>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<ReservationQueryData>> Put(ReservationUpdateRequest request, Guid userId)
    {
        var response = await _updateCommand.Execute(request, userId);

        return new StandardResult<ReservationQueryData>()
        {
            Success = true,
            Data = response
        };
    }
}
