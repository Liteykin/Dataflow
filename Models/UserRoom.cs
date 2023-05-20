namespace Dataflow.Models;

public class UserRoom
{
    public int UserId { get; set; } = default!;
    public int RoomId { get; set; } = default!;
    public bool IsAdmin { get; set; } = default!;
    public DateTime JoinDate { get; set; } = DateTime.Now;

    // Navigation properties
    public User User { get; set; } = null!;
    public Room Room { get; set; } = null!;
}