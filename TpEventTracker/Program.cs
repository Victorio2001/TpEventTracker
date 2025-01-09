// See https://aka.ms/new-console-template for more information
using EventTracker.DataSource;
using EventTracker.DataSource.Interfaces;
using EventTracker.Model;

string filesPath = "../EventTracker.DataSource/JsonFiles/Events.json";

Console.WriteLine($"Veuillez rentrez le chemin de vôtre fichier json (laisser vide si utiliser default Event)");
var stringSimpleEvent = Console.ReadLine(); 
var CheckEmptyString = stringSimpleEvent.Length > 0;
//condition ? consequent : alternative
string filePath = CheckEmptyString?  stringSimpleEvent : "../EventTracker.DataSource/JsonFiles/Event.json";

EventDataSource eventDataSource = new EventDataSource();

IEnumerable<EventModel> eventsModel = eventDataSource.GetEventsFromJSON(filesPath);
void DisplayEvents(IEnumerable<EventModel> events)
{
    Console.WriteLine($"{eventsModel.ToList().Count} events trouvée");
    Console.WriteLine("------Affichage events-------");
    for (int i = 0; i < events.ToList().Count; i++)
    {
        Console.WriteLine("-----------------------------");
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