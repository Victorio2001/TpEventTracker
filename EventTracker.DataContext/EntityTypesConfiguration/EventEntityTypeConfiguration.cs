using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventTracker.Model;

namespace EventTracker.DataContext.EntityTypesConfiguration
{
    public class EventEntityTypeConfiguration : IEntityTypeConfiguration<EventModel>
    {
        public void Configure(EntityTypeBuilder<EventModel> builder)
        {
            builder.HasKey(e => e.Guid);

            builder.HasOne(e => e.Location) // Relation vers Location
                .WithMany(l => l.Events) // Relation inverse (plusieurs Events pour un Location)
                .HasForeignKey(e => e.LocationId); // Clé étrangère
        }
    }
}