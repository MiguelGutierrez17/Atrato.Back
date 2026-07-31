using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrato.Entities.Documents;

public class TimeZoneData
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Description { get; set; }
    public int MinutesToUtc { get; set; }
    public ICollection<Enterprise> Enterprises { get; set; } = new List<Enterprise>();
}