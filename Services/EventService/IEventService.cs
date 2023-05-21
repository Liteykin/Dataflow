using Dataflow.Models;

namespace Dataflow.Services.EventService;

public interface IEventService
{
    List<Event> GetAllEvents();
    Event? GetUserById(int id);
    List<Event?> AddEvent(Event? newEvent);
    bool DeleteEvent(int id);
    Event? PatchEvent(int id, User updatedEvent);
}