namespace Atrato.Entities.DTO.RefreshToken;

public class RefreshTokenCreateRequest
{
    public string Token { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public bool isExpired { get; set; }
    public DateTime? ExpiredAt { get; set; }
    public Guid UserId { get; set; }
}
