using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using EventTracker.DataSource;
using EventTracker.Model;
using EventTracker.WebUI.Models;


namespace EventTracker.WebUI.Controllers;

public class EventController : Controller
{

    public EventController()
    {
    
    }

    
    /// <summary>
    /// Ici nous avons 
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        var dataSource = new EventDataSource();
        var events = dataSource.GetEventsFromJSON("../EventTracker.DataSource/JsonFiles/Events.json");
        
        //List<EventViewModel> modelEvents = new List<EventViewModel>();
        
        EventIndexViewModel viewModel = new EventIndexViewModel();
        viewModel.pageTitle = "Events";
        viewModel.Events = new List<EventViewModel>();
        
        foreach (var t in events)
        {
            var eventViewModel = new EventViewModel
            {
                Name = t.Name,
                MaxParticipants = t.MaxParticipants,
            };
            viewModel.Events.Add(eventViewModel);
        }

        /*viewModel.Events = events.Select(e=> new EventViewModel
        {
           Name =  e.Name,
        }).ToList();*/
        
        return View(viewModel);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        AddEventViewModel viewModel = new AddEventViewModel();
        return View();
    }

    [HttpPost]
    public IActionResult Create(AddEventViewModel model)
    {
        if (ModelState.IsValid)
        {
        }
        return View(model);
    }
}