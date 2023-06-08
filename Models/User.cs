namespace Dataflow.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = default!;
    public bool IsOnline { get; set; } = default!;
    public string ProfilePicUrl { get; set; } = string.Empty;

    // Navigation properties
    public List<Contact> ContactList { get; set; } = new List<Contact>();
    public List<Reminder> ReminderList { get; set; } = new List<Reminder>();
    public List<ToDo> ToDoList { get; set; } = new List<ToDo>();
}