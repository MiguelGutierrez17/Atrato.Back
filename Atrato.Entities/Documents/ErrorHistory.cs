using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrato.Entities.Documents;

public class ErrorHistory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string? Message { get; set; }
    public string? StackTrace { get; set; }
    public string? Path { get; set; }
    public string? Method { get; set; }
    public string? Payload { get; set; }
    [Required]
    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
}