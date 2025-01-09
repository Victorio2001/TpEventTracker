using EventTracker.Model;

namespace EventTracker.DataSource.Interfaces;

public interface IEventDataSource
{
    EventModel GetEventFromJSON(string filePath);
    IEnumerable<EventModel> GetEventsFromJSON(string filePath);
}