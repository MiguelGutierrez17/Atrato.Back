namespace Atrato.Entities.DTO.User;

public class EnterpriseMembershipData
{
    public Guid EnterpriseId { get; set; }
    public string Enterprise { get; set; }
    public bool IsAdminEnterprise { get; set; }
    public int ReservationsByMonth { get; set; }
}
