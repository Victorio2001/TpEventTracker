// See https://aka.ms/new-console-template for more information
using EventTracker.DataSource;
using EventTracker.DataSource.Interfaces;
using EventTracker.Model;

string filePath = "../EventTracker.DataSource/JsonFiles/Event.json";
string filesPath = "../EventTracker.DataSource/JsonFiles/Events.json";



EventDataSource eventDataSource = new EventDataSource();


List<EventModel> eventsModel = eventDataSource.GetEventsFromJSON(filesPath);
void DisplayEvents(List<EventModel> events)
{
    Console.WriteLine($"{eventsModel.Count} events trouvée");
    Console.WriteLine("------Affichage events-------");
    for (int i = 0; i < events.Count; i++)
    {
        Console.WriteLine("-----------------------------");
        Console.WriteLine($"Event Name: {events[i].Name}");
        Console.WriteLine($"Event Date: {events[i].Date}");
        Console.WriteLine($"Location: {events[i].Location.Name}, {events[i].Location.Address}, {events[i].Location.City}, {events[i].Location.PostalCode}");
        Console.WriteLine($"Capacity: {events[i].Location.Capacity}");
        Console.WriteLine("-----------------------------");
    }
    Console.WriteLine("------Affichage events-------");
}
DisplayEvents(eventsModel);



EventModel eventModel = eventDataSource.GetEventFromJSON(filePath);
void DisplayEvent(EventModel eventModel)
{
    Console.WriteLine("----Affichage de l'event-----");
    Console.WriteLine("-----------------------------");
    Console.WriteLine($"Event Name: {eventModel.Name}");
    Console.WriteLine($"Event Date: {eventModel.Date}");
    Console.WriteLine($"Location: {eventModel.Location.Name}, {eventModel.Location.Address}, {eventModel.Location.City}, {eventModel.Location.PostalCode}");
    Console.WriteLine($"Capacity: {eventModel.Location.Capacity}");
    Console.WriteLine("-----------------------------");
    Console.WriteLine("----Affichage de l'event-----");
}
DisplayEvent(eventModel);
Console.ReadLine();