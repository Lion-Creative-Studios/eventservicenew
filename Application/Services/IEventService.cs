using Application.Models;

namespace Application.Services
{
    public interface IEventService
    {
        Task<EventResult> CreateEventAsync(CreateEventRequest request);
        Task<EventResult<EventWithPrice?>> GetEventAsync(string eventId);
        Task<EventResult<IEnumerable<EventWithPrice>>> GetEventsAsync();
    }
}