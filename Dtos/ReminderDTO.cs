namespace Dataflow.Dtos
{
    public class ReminderDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ReminderTime { get; set; }
    }

    public class GetReminderDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ReminderTime { get; set; }
    }

    public class AddReminderDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ReminderTime { get; set; }
    }

    public class UpdateReminderDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ReminderTime { get; set; }
    }
}