using EventTracker.Model;
using Microsoft.EntityFrameworkCore;

namespace EventTracker.DataContext.SeedData;

public static class SeedDataLocation
{
    public static void SeedDatabase(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<LocationModel>()
        .HasData(
            new LocationModel { Id = 1, Name = "Stade de France", Address = "ZAC du Cornillon Nord", City = "Saint-Denis", PostalCode = "93216", Capacity = 80000 },
            new LocationModel { Id = 2, Name = "Accor Arena", Address = "8 Boulevard de Bercy", City = "Paris", PostalCode = "75012", Capacity = 20000 },
            new LocationModel { Id = 3, Name = "Halle Tony Garnier", Address = "20 Place des Docteurs Mérieux", City = "Lyon", PostalCode = "69007", Capacity = 17000 }
        );
}
}