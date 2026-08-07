namespace Atrato.Entities.DTO.WorkStation;

public class WorkStationQueryData
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid WorkplaceId { get; set; }
    public string Workplace { get; set; }
    public Guid WorkStationStateId { get; set; }
    public string WorkStationState { get; set; }
    public Guid OwnerArea { get; set; }
    public string OwnerAreaLabel { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
}