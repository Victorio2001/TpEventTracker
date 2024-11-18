using System.Text.Json;
using EventTracker.DataSource.Interfaces;
using EventTracker.Model;

namespace EventTracker.DataSource;

public class EventDataSource : IEventDataSource
{
    /// <summary>
    /// Ici ma méthode --GetEventFromJSON-- provient du contrat via mon interface --IEventDataSource--.
    /// Ma méthode viens déserializer mes fichiers json en via mes classes --EventModel && Location Model-- avec leurs props matcher sur les values json.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public EventModel GetEventFromJSON(string filePath)
    {
        try
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.io.file.readalltext?view=net-9.0
            //Utilisation de la méthode ReadAllText --Opens a text file, reads all the text in the file, and then closes the file--.
            string jsonString = File.ReadAllText(filePath);
            /*
             *  WeatherForecast? weatherForecast = 
                JsonSerializer.Deserialize<WeatherForecast>(jsonString);
             */
            EventModel eventModel = JsonSerializer.Deserialize<EventModel>(jsonString);
            return eventModel;
        }
        catch (FileNotFoundException ex)
        {
            throw new Exception("Fichier introuvable", ex);
        }
        catch (JsonException ex)
        {
            throw new Exception("Erreur Json", ex);
        }
        catch (Exception ex)
        {
            throw new Exception("Erreur inconnue", ex);
        }
    }
    
//!  https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/deserialization
/*
* using System.Text.Json;

namespace DeserializeExtra
{
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }
        public string? SummaryField;
        public IList<DateTimeOffset>? DatesAvailable { get; set; }
        public Dictionary<string, HighLowTemps>? TemperatureRanges { get; set; }
        public string[]? SummaryWords { get; set; }
    }

    public class HighLowTemps
    {
        public int High { get; set; }
        public int Low { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            string jsonString =
                """
                {
                  "Date": "2019-08-01T00:00:00-07:00",
                  "TemperatureCelsius": 25,
                  "Summary": "Hot",
                  "DatesAvailable": [
                    "2019-08-01T00:00:00-07:00",
                    "2019-08-02T00:00:00-07:00"
                  ],
                  "TemperatureRanges": {
                                "Cold": {
                                    "High": 20,
                      "Low": -10
                                },
                    "Hot": {
                                    "High": 60,
                      "Low": 20
                    }
                            },
                  "SummaryWords": [
                    "Cool",
                    "Windy",
                    "Humid"
                  ]
                }
                """;
                
            WeatherForecast? weatherForecast = 
                JsonSerializer.Deserialize<WeatherForecast>(jsonString);

            Console.WriteLine($"Date: {weatherForecast?.Date}");
            Console.WriteLine($"TemperatureCelsius: {weatherForecast?.TemperatureCelsius}");
            Console.WriteLine($"Summary: {weatherForecast?.Summary}");
        }
    }
}
// output:
//Date: 8/1/2019 12:00:00 AM -07:00
//TemperatureCelsius: 25
//Summary: Hot
*/
}