namespace Atrato.Entities.DTO.Notification;

public class NotificationQueryData
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Guid EntityTypeId { get; set; }
    public string EntityType { get; set; }
    public Guid Receipter { get; set; }
    public string ReceipterLabel { get; set; }
    public string EmailSender { get; set; }
    public string EmailReceipter { get; set; }
    public string Description { get; set; }
    public bool isEmail { get; set; }
    public bool Read { get; set; }
    public bool State { get; set; }
    public Guid EnterpriseId { get; set; }
    public string Enterprise { get; set; }
}