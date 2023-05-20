namespace Dataflow.Models;

public class Message
{
    public int Id { get; set; }
    public int UserId { get; set; } = default!;
    public bool IsBot { get; set; } = default!;
    public int RoomId { get; set; } = default!;
    public string Content { get; set; } = string.Empty;
    public string Attachment { get; set; } = string.Empty;
    public bool IsEdited { get; set; } = default!;
    public DateTime Timestamp { get; set; } = DateTime.Now;
    public DateTime EditedAt { get; set; } = DateTime.Now;

    //Navigation Properties
    public User User { get; set; } = null!;
    public Room Room { get; set; } = null!;
    public List<MessageReaction> MessageReactions { get; set; } = null!;
}