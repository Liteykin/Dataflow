namespace Dataflow.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; } = default!;

    // Navigation properties
    public List<Contact> ContactList { get; set; } = new List<Contact>();
    public List<Note> NoteList { get; set; } = new List<Note>();
    public List<Reminder> ReminderList { get; set; } = new List<Reminder>();
    public List<ToDo> ToDoList { get; set; } = new List<ToDo>();
}