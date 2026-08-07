namespace Atrato.Entities.DTO.Notification;

public class NotificationCreateRequest
{
    public DateTime Date { get; set; }
    public Guid EntityTypeId { get; set; }
    public Guid Receipter { get; set; }
    public string EmailSender { get; set; }
    public string EmailReceipter { get; set; }
    public string Description { get; set; }
    public bool isEmail { get; set; }
    public bool Read { get; set; }
    public bool State { get; set; }
    public Guid EnterpriseId { get; set; }
}