using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventTracker.Model;

namespace EventTracker.DataContext.EntityTypesConfiguration
{
    public class LocationEntityTypeConfiguration : IEntityTypeConfiguration<LocationModel>
    {
        public void Configure(EntityTypeBuilder<LocationModel> builder)
        {
            builder.HasKey(l => l.Id);

            builder.HasMany(l => l.Events) // Relation avec EventModel
                .WithOne(e => e.Location) // Relation inverse
                .HasForeignKey(e => e.LocationId);
        }
    }
}