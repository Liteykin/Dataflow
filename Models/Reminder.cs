namespace Dataflow.Models;

public class Reminder
{
    public int Id { get; set; }
    public int UserId { get; set; } = default!;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ReminderTime { get; set; } = default!;
    
    // Navigation Properties
    public User User { get; set; } = default!;
}