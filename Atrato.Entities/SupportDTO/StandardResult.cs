namespace Atrato.Entities.SupportDTO;

public class StandardResult<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }
}