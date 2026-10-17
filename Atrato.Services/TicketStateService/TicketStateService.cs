using Atrato.Entities.DTO.TicketState;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.TicketStateQueryObject;

namespace Atrato.Services.TicketStateService;

public class TicketStateService : ITicketStateService
{
    private readonly ITicketStateQueryObject _queryObject;

    public TicketStateService(ITicketStateQueryObject queryObject)
    {
        _queryObject = queryObject;
    }

    public async Task<StandardResult<List<TicketStateQueryData>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().GetAll(cancellationToken);

        return new StandardResult<List<TicketStateQueryData>>()
        {
            Data = response,
            Success = true
        };
    }

    public async Task<StandardResult<TicketStateQueryData?>> ById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _queryObject.Clear().ForId(id).FirstOrDefault(cancellationToken);

        return new StandardResult<TicketStateQueryData?>()
        {
            Success = true,
            Data = response
        };
    }
}
