namespace Atrato.Entities.DTO.ErrorHistory;

public class ErrorHistoryQueryData
{
    public Guid Id { get; set; }
    public string? Message { get; set; }
    public string? StackTrace { get; set; }
    public string? Path { get; set; }
    public string? Method { get; set; }
    public string? Payload { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
}