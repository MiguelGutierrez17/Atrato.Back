namespace Atrato.Entities.DTO.Guide;

public class GuideQueryData
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public Guid FileId { get; set; }
    public string File { get; set; }
    public Guid EnterpriseId { get; set; }
    public string Enterprise { get; set; }
    public DateTime Date { get; set; }
    public bool State { get; set; }
}
