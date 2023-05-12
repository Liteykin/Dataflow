namespace Dataflow.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber{ get; set; }
    public string PasswordHash { get; set; }
    public DateTime LastLogin { get; set; }
    public bool IsOnline { get; set; }
    public string ProfilePicUrl { get; set; }
    
    // Navigation properties
    public List<UserRoom> UserRooms { get; set; }
    public List<Message> Messages { get; set; }
    public List<MessageReaction> MessageReactions { get; set; }
    public List<Bot> Bots { get; set; }
}