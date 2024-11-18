// See https://aka.ms/new-console-template for more information
using EventTracker.DataSource;
using EventTracker.DataSource.Interfaces;
using EventTracker.Model;

string filePath = "../EventTracker.DataSource/JsonFiles/Event.json";

EventDataSource eventDataSource = new EventDataSource();


EventModel eventModel = eventDataSource.GetEventFromJSON(filePath);

void DisplayEvent(EventModel eventModel)
{
    Console.WriteLine($"Event Name: {eventModel.Name}");
    Console.WriteLine($"Event Date: {eventModel.Date}");
    Console.WriteLine($"Location: {eventModel.Location.Name}, {eventModel.Location.Address}, {eventModel.Location.City}, {eventModel.Location.PostalCode}");
    Console.WriteLine($"Capacity: {eventModel.Location.Capacity}");
}
DisplayEvent(eventModel);

Console.ReadLine();