using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using EventTracker.DataSource;
using EventTracker.DataSource.Interfaces;
using EventTracker.Model;
using EventTracker.WebUI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;


namespace EventTracker.WebUI.Controllers;

public class EventController : Controller
{

    private readonly IEventDataSource _eventDataSource;
    private readonly ILogger<EventController> _logger;
    //! Le contexte de base de données est utilisé dans chacune des méthodes la CRUD du contrôleur.
    public EventController(IEventDataSource eventDataSource, ILogger<EventController> logger)
    {
        _eventDataSource = eventDataSource;
        _logger = logger;
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
        var dataSource = new EventDataSource();
        var events = dataSource.GetEventsFromJSON("../EventTracker.DataSource/JsonFiles/Events.json");

        AddEventViewModel viewModel = new AddEventViewModel();
        viewModel.locations = GetLocations();
  
        
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Create(AddEventViewModel model)
    {
       
        if (ModelState.IsValid)
        {
            _logger.LogInformation("Hello World! Logging is {Description}.", "fun");
            var nom = model.Eve.Name;
            Console.WriteLine("Nom: " + nom);
        }
        return View(model);
    }

    private List<SelectListItem> GetLocations()
    {
        var dataSource = new EventDataSource();
        var events = dataSource.GetEventsFromJSON("../EventTracker.DataSource/JsonFiles/Events.json");
        
        List<SelectListItem> Items = new List<SelectListItem>();
        foreach (var eventmodel in events)
        {
            Items.Add(new SelectListItem
                {
                    Text = eventmodel.Name,
                    Value = eventmodel.Location.Id.ToString()
                }
            );
        }

        return Items;
    }
}

