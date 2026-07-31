using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrato.Entities.Documents;

public class RefreshToken
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    public string Token { get; set; }
    [Required]
    public DateTime CreationDate { get; set; }
    [Required]
    public DateTime ExpirationDate { get; set; }
    [Required]
    public bool isExpired { get; set; }
    [Required]
    public DateTime ExpiredAt { get; set; }
    [Required]
    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
}