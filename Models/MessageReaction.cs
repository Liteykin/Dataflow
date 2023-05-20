namespace Dataflow.Models;

public class MessageReaction
{
    public int Id { get; set; }
    public int MessageId { get; set; } = default!;
    public string UserId { get; set; } = string.Empty;
    public int ReactionId { get; set; } = default!;
    public DateTime Timestamp { get; set; } = DateTime.Now;

    // Navigation properties
    public Message Message { get; set; } = null!;
    public User User { get; set; } = null!;
    public ReactionType ReactionType { get; set; } = null!;
}