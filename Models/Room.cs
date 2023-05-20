namespace Dataflow.Models;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime LastActivity { get; set; } = DateTime.Now;
    public int CreatedByUserId { get; set; } = default!;
    public User CreatedByUser { get; set; } = default!;

    // Navigation properties
    public List<UserRoom> UserRooms { get; set; }
    public List<Message> Messages { get; set; }
    public List<Bot> Bots { get; set; }
}