using Atrato.Commands.TicketCommands.Create;
using Atrato.Commands.TicketCommands.Update;
using Atrato.Entities.DTO.Ticket;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.TicketQueryObject;

namespace Atrato.Services.TicketService;

public class TicketService : ITicketService
{
    private readonly ITicketCreateCommand _createCommand;
    private readonly ITicketUpdateCommand _updateCommand;
    private readonly ITicketQueryObject _queryObject;

    public TicketService(
        ITicketCreateCommand createCommand,
        ITicketUpdateCommand updateCommand,
        ITicketQueryObject queryObject)
    {
        _createCommand = createCommand;
        _updateCommand = updateCommand;
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<TicketQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.GetAll(cancellationToken);

        return new StandardResult<List<TicketQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<TicketQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<TicketQueryData?>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<List<TicketQueryData>>> ByWorkStation(Guid workStationId, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForWorkStation(workStationId).GetAll(cancellationToken);

        return new StandardResult<List<TicketQueryData>>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<List<TicketQueryData>>> ByEnterprise(Guid enterpriseId, CancellationToken cancellationToken)
    {
        var response = await _queryObject.ForEnterprise(enterpriseId).GetAll(cancellationToken);

        return new StandardResult<List<TicketQueryData>>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<TicketQueryData>> Post(TicketCreateRequest request, Guid userId)
    {
        var response = await _createCommand.Execute(request, userId);

        return new StandardResult<TicketQueryData>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<TicketQueryData>> Put(TicketUpdateRequest request, Guid userId)
    {
        var response = await _updateCommand.Execute(request, userId);

        return new StandardResult<TicketQueryData>()
        {
            Success = true,
            Data = response
        };
    }
}
