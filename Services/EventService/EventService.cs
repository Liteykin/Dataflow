using Dataflow.Models;
using Dataflow.Services.UserService;

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

    public Event? GetEventById(int id)
    {
        return _events.FirstOrDefault(e => e.Id == id)??
               throw new Exception("Event not found");
    }

    public List<Event?> AddEvent(Event? newEvent)
    {
        if (newEvent != null) _events.Add(newEvent);
        return _events;
    }

    public bool DeleteEvent(int id)
    {
        var user = _events.FirstOrDefault(e => e.Id == id);
        if (user == null) return false;
        _events.Remove(user);
        return true;
    }

    public Event? PatchEvent(int id, Event updatedEvent)
    {
        var existingEvent = _events.FirstOrDefault(e => e.Id == id);
        if (existingEvent == null) return null;
        existingEvent.Title = updatedEvent.Title;
        existingEvent.Description = updatedEvent.Description;
        existingEvent.Start = updatedEvent.Start;
        existingEvent.End = updatedEvent.End;
        existingEvent.IsAllDay = updatedEvent.IsAllDay;
        existingEvent.Location = updatedEvent.Location;
        existingEvent.UpdatedAt = DateTime.Now;
        return existingEvent;
    }
}