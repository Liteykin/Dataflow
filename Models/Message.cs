namespace Dataflow.Models;

public class Message
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public bool IsBot { get; set; }
    public int RoomId { get; set; }
    public string Content { get; set; }
    public string Attachment { get; set; }
    public bool IsEdited { get; set; }
    public DateTime Timestamp { get; set; }
    public DateTime EditedAt { get; set; }

    //Navigation Properties
    public User User { get; set; }
    public Room Room { get; set; }
    public List<MessageReaction> MessageReactions { get; set; }
}