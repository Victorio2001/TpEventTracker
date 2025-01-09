using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventTracker.WebUI.Models;

public class AddEventViewModel
{
    public EventViewModel? Eve { get; set; }
    public List<SelectListItem>? locations { get; set; }
}