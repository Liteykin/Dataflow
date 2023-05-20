﻿namespace Dataflow.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime LastLogin { get; set; } = DateTime.Now;
    public bool IsOnline { get; set; } = default!;
    public Role Role { get; set; } = default!;
    public string ProfilePicUrl { get; set; } = string.Empty;

    // Navigation properties
    public List<UserRoom> UserRooms { get; set; } = null!;
    public List<Message> Messages { get; set; } = null!;
    public List<MessageReaction> MessageReactions { get; set; } = null!;
    public List<Bot> Bots { get; set; } = null!;
}