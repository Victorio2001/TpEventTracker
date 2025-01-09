using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EventTracker.DataContext
{
    public class EventTrackerContextFactory : IDesignTimeDbContextFactory<EventTrackerContext>
    {
        public EventTrackerContext CreateDbContext(string[] args)
        {
            // Récupération de la configuration 
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = configurationBuilder.Build();

            // Création du contexte en lui passabt la configuration
            DbContextOptionsBuilder<EventTrackerContext> builder = new DbContextOptionsBuilder<EventTrackerContext>();

            // Récupération de la chaine de configuration dans le fichier de configuration
            builder.UseSqlServer(configuration.GetConnectionString("EventTrackerContext"));
            
            return new EventTrackerContext(builder.Options);
        }
    }


}