using EventTracker.Model;
using Microsoft.EntityFrameworkCore;

namespace EventTracker.DataContext.SeedData;

public static class SeedDataEvent
{
    public static void SeedDatabase(ModelBuilder modelBuilder)
{
    // Ajout des données pour la table "Event"
    modelBuilder.Entity<EventModel>()
        .HasData(
            new EventModel
            {
                Guid = Guid.NewGuid(),
                Date = DateTime.Now,
                Description = "Une compétition intergalactique époustouflante où les meilleurs s'affrontent pour dominer l'univers.",
                Name = "Star Reign Championship",
                PrizePool = "100,000 EUR",
                Slug = "star-reign-championship",
                Sponsors = new List<string> { "Red Bull", "Alienware", "Logitech" },
                Status = "Open",
                StreamingUrl = "https://twitch.tv/star_reign_championship",
                Tags = new List<string> { "eSport", "Galactic", "Star Reign" },
                LocationId = 1
            },
            new EventModel
            {
                Guid = Guid.NewGuid(),
                Date = DateTime.Now.AddMonths(1),
                Description = "La finale du tournoi mondial de League of Legends, un rendez-vous incontournable pour les fans d'eSport.",
                Name = "League of Legends Finals",
                PrizePool = "500,000 EUR",
                Slug = "league-of-legends-finals",
                Sponsors = new List<string> { "Riot Games", "Corsair", "SteelSeries" },
                Status = "Open",
                StreamingUrl = "https://twitch.tv/lol_worlds",
                Tags = new List<string> { "eSport", "League of Legends", "Worlds" },
                LocationId = 2
            }
        );
}
}