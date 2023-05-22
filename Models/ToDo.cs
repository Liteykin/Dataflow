namespace Dataflow.Models;

public class ToDo
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; } = default!;
    public bool IsCompleted { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = default!;
    public DateTime UpdatedAt { get; set; } = default!;
}