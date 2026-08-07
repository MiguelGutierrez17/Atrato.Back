using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrato.Entities.Documents;

public class FileDb
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [MaxLength(20)]
    public string Extension { get; set; }
    [Required]
    public DateTime DateUpload { get; set; }
    [Required]
    public string TypeFile { get; set; }
    [Required]
    public Guid StorageId { get; set; }
    [Required]
    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    [Required]
    public bool State { get; set; }
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    public ICollection<News> News { get; set; } = new List<News>();
}