using Dataflow.Models;

namespace Dataflow.Services.EventService;

public interface IEventService
{
    List<Event> GetAllEvents();
    Event? GetEventById(int id);
    List<Event?> AddEvent(Event? newEvent);
    bool DeleteEvent(int id);
    Event? PatchEvent(int id, Event updatedEvent);
}