using Dataflow.Models;

namespace Dataflow.Services.EventService;

public class EventService : IEventService
{
    private static List<Event> _events = new List<Event>()
    {
        new Event()
        {
            Id = 1,
            UserId = 1,
            Title = "Event 1",
            Description = "Event 1 Description",
            Start = DateTime.Now,
            End = DateTime.Now,
            IsAllDay = false,
            Location = "Event 1 Location",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        }
    };

    public List<Event> GetAllEvents()
    {
        return _events;
    }

    public Event? GetUserById(int id)
    {
        return _events.FirstOrDefault(u => u.Id == id);
    }

    public List<Event?> AddEvent(Event? newEvent)
    {
        if (newEvent != null) _events.Add(newEvent);
        return _events;
    }

    public bool DeleteEvent(int id)
    {
        var user = _events.FirstOrDefault(u => u.Id == id);
        if (user == null) return false;
        _events.Remove(user);
        return true;
    }

    public Event? PatchEvent(int id, User updatedEvent)
    {
        var existingEvent = _events.FirstOrDefault(u => u.Id == id);
        if (existingEvent == null) return null;
        existingEvent.Title = updatedEvent.FirstName;
        existingEvent.Description = updatedEvent.LastName;
        existingEvent.Start = updatedEvent.CreatedAt;
        existingEvent.End = updatedEvent.CreatedAt;
        existingEvent.IsAllDay = updatedEvent.IsOnline;
        existingEvent.Location = updatedEvent.PhoneNumber;
        existingEvent.UpdatedAt = DateTime.Now;
        return existingEvent;
    }
}