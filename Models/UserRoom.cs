namespace Dataflow.Models;

public class UserRoom
{
    public int UserId { get; set; }
    public int RoomId { get; set; }
    public bool IsAdmin { get; set; }
    public DateTime JoinDate { get; set; }
    
    // Navigation properties
    public User User { get; set; }
    public Room Room { get; set; }
}