using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrato.Entities.Documents;

public class Invitation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    [Required]
    [MaxLength(64)]
    public string Code { get; set; }
    [Required]
    public bool State { get; set; }
    [Required]
    public int NumberAttempts { get; set; }
    [Required]
    public DateTime CreationDate { get; set; }
    [Required]
    public DateTime ExpirationDate { get; set; }
    public DateTime? UsedAt { get; set; }
}