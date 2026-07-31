using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrato.Entities.Documents;

public class Ticket
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    public Guid WorkStationId { get; set; }
    [ForeignKey(nameof(WorkStationId))]
    public WorkStation WorkStation { get; set; }
    [Required]
    [MaxLength(200)]
    public string Title { get; set; }
    [Required]
    [MaxLength(1000)]
    public string Body { get; set; }
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public Guid TicketStateId { get; set; }
    [ForeignKey(nameof(TicketStateId))]
    public TicketState TicketState { get; set; }
    public ICollection<FileDb> Files { get; set; } = new List<FileDb>();
}