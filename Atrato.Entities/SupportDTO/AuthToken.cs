using Atrato.Entities.DTO.User;

namespace Atrato.Entities.SupportDTO;

public class AuthToken
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public LoginUserData User { get; set; }
}