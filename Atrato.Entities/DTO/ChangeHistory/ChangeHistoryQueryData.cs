namespace Atrato.Entities.DTO.ChangeHistory;

public class ChangeHistoryQueryData
{
    public Guid Id { get; set; }
    public Guid EntityTypeId { get; set; }
    public string EntityType { get; set; }
    public Guid ItemId { get; set; }
    public Guid UserActionId { get; set; }
    public string UserAction { get; set; }
    public string ValueName { get; set; }
    public string PreviousValue { get; set; }
    public string NewValue { get; set; }
    public Guid ActionUser { get; set; }
    public string ActionUserLabel { get; set; }
    public DateTime ActionDate { get; set; }
    public Guid EnterpriseId { get; set; }
    public string Enterprise { get; set; }
}
