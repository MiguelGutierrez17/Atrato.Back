namespace Atrato.Entities.DTO.WorkStation;

public class WorkStationUpdateRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid WorkplaceId { get; set; }
    public Guid WorkStationStateId { get; set; }
    public Guid OwnerArea { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
}