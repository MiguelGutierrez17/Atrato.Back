using System.ComponentModel.DataAnnotations;

namespace Atrato.Entities.SupportDTO;

public class CheckUserRequest
{
    [EmailAddress]
    public required string Email { get; set; }
}
