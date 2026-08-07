namespace Atrato.Entities.DTO.Ticket;

public class TicketQueryData
{
    public Guid Id { get; set; }
    public Guid WorkStationId { get; set; }
    public string WorkStation { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public Guid UserId { get; set; }
    public string User { get; set; }
    public DateTime Date { get; set; }
    public Guid TicketStateId { get; set; }
    public string TicketState { get; set; }
}