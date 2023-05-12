namespace Dataflow.Models;

public class MessageReaction
{
    public int Id { get; set; }
    public int MessageId { get; set; }
    public string UserId { get; set; }
    public string ReactionId { get; set; }
    public DateTime Timestamp { get; set; }
    
    // Navigation properties
    public Message Message { get; set; }
    public User User { get; set; }
    public ReactionType ReactionType { get; set; }
}