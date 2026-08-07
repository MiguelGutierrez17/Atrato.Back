namespace Atrato.Entities.DTO.TicketAudit;

public class TicketAuditCreateRequest
{
    public Guid WorkStationId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public Guid TicketStateId { get; set; }
    public Guid ItemId { get; set; }
    public Guid UserChange { get; set; }
    public DateTime DateChange { get; set; }
    public int AuditAction { get; set; }
}