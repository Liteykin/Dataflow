namespace Dataflow.Models;

public class ServiceResponse<T>
{
    public T? Data { get; set; }
    public bool Success { get; set; } = default!;
    public string? Message { get; set; } = string.Empty;
}