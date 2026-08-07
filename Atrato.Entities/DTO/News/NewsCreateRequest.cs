namespace Atrato.Entities.DTO.News;

public class NewsCreateRequest
{
    public string Title { get; set; }
    public string? Body { get; set; }
    public Guid? FileId { get; set; }
    public bool State { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid EnterpriseId { get; set; }
}