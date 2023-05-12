namespace Dataflow.Models;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastActivity { get; set; }
    public int CreatedByUserId { get; set; }
    public User CreatedByUser { get; set; }
    
    // Navigation properties
    public List<UserRoom> UserRooms { get; set; }
    public List<Message> Messages { get; set; }
    public List<Bot> Bots { get; set; }
}