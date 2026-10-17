using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atrato.Entities.Documents;

[Index(nameof(Token))]
public class RefreshToken
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(64)]
    public string Token { get; set; }
    [Required]
    public DateTime CreationDate { get; set; }
    [Required]
    public DateTime ExpirationDate { get; set; }
    [Required]
    public bool isExpired { get; set; }
    public DateTime? ExpiredAt { get; set; }
    [Required]
    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
}