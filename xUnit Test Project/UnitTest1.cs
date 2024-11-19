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
    public void Test1()
    {
        Assert.Pass();
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