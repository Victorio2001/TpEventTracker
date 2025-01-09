using EventTracker.DataSource;
using EventTracker.Model;

namespace xUnit_Test_Project;

public class Tests
{
    //https://learn.microsoft.com/fr-fr/dotnet/core/testing/unit-testing-with-dotnet-test
    [SetUp]
    public void Setup()
    {
    }

    /// <summary>
    /// Ici je vais vérifier si un élément de ma liste est un doublon
    /// </summary>
    [Test]
    public void caca()
    {
        EventDataSource eventDataSource = new EventDataSource();
        string filePath = "D:\\ProjetCSharp\\TpEventTracker\\EventTracker.DataSource\\JsonFiles\\Event.json";
        EventModel eventModel = eventDataSource.GetEventFromJSON(filePath);
      
        bool PleinLesMecs = eventModel.CurrentParticipants < 1000;
        Console.WriteLine(PleinLesMecs);
        Assert.IsTrue(PleinLesMecs, "Le nombre de participants dépasse la limite autorisée (1000).");
    }
    /*
     * public bool IsPrime(int candidate)
        {
        if (candidate < 2)
        {
            return false;
        }
        throw new NotImplementedException("Not fully implemented.");
        }
     */
}