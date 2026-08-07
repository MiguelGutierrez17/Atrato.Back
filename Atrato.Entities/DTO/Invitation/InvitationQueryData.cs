namespace Atrato.Entities.DTO.Invitation;

public class InvitationQueryData
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string User { get; set; }
    public string Code { get; set; }
    public bool State { get; set; }
    public int NumberAttempts { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public DateTime? UsedAt { get; set; }
}
