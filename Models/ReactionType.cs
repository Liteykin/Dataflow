namespace Dataflow.Models;

public class ReactionType
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;

    // Navigation properties
    public List<MessageReaction> MessageReactions { get; set; }
}