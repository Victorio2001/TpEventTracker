using Microsoft.EntityFrameworkCore;
using EventTracker.WebUI.Models;

namespace EventTracker.WebUI.Data;

public class EventTrackerContext : DbContext
{
    public EventTrackerContext (DbContextOptions<EventTrackerContext> options)
        : base(options)
    {
    }
    //! définition des entity à migrer + lien entre mes objets et tables
    //? DbSet fournis les outils crud comme doctrinne en php
    public DbSet<EventViewModel> Evenements { get; set; } = default!;

    //public DbSet<User> User { get; set; } = default!;
}