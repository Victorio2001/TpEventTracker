using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EventTracker.WebUI.Models;

namespace EventTracker.WebUI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var homeViewModel = new HomeViewModel();
        homeViewModel.pageTitle = "Home";
        homeViewModel.welcomeMessage = "Salut victorio";

        ViewBag.MyMessageToUsers = "Hello from me.";
        ViewBag.AnswerText = "Your answer goes here.";
        return View(homeViewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}