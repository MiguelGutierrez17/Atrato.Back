using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrato.Entities.Documents;

public class Guide
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(200)]
    public string Title { get; set; }
    [MaxLength(1000)]
    public string Body { get; set; }
    [Required]
    public Guid FileId { get; set; }
    [ForeignKey(nameof(FileId))]
    public FileDb FileDb { get; set; }
    [Required]
    public Guid EnterpriseId { get; set; }
    [ForeignKey(nameof(EnterpriseId))]
    public Enterprise Enterprise { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public bool State { get; set; }
}