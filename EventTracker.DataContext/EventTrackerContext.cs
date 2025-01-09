using Microsoft.EntityFrameworkCore;
using EventTracker.Model;
using EventTracker.DataContext.EntityTypesConfiguration;

namespace EventTracker.DataContext
{
    public class EventTrackerContext : DbContext
    {
        protected EventTrackerContext()
        {
        }

        public EventTrackerContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Application des configurations des entités
            modelBuilder.ApplyConfiguration(new EventEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LocationEntityTypeConfiguration());
        }

        // Déclaration des tables
        public DbSet<EventModel> Event { get; set; }
        public DbSet<LocationModel> Location { get; set; }
    }
}