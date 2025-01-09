namespace EventTracker.WebUI.Models;

public class EventIndexViewModel
{
    public List<EventViewModel>? 
        Events { get; set; }
    public string pageTitle { get; set; }
    public string welcomeMessage { get; set; }
}