namespace Atrato.Entities.DTO.Ticket;

public class TicketCreateRequest
{
    public Guid WorkStationId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public Guid TicketStateId { get; set; }
}