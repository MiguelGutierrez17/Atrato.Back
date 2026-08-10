using System.ComponentModel.DataAnnotations;

namespace Atrato.Entities.SupportDTO;

public class AuthRequest
{
    [EmailAddress]
    public required string Email { get; set; }

    [RegularExpression(@"^\d{6}$")]
    public required string Code { get; set; }
}