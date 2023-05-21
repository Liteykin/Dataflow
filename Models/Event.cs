namespace Dataflow.Models;

public class Event
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime? Start { get; set; } = default!;
    public DateTime? End { get; set; } = default!;
    public bool IsAllDay { get; set; } = default!;
    public string Location { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; } = default!;
    public DateTime? UpdatedAt { get; set; } = default!;
}