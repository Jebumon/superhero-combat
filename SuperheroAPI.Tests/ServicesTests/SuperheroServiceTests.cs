using SuperheroAPI.Controllers;
using SuperheroAPI.Models;
using SuperheroAPI.Services;
namespace SuperheroAPI.Tests.ControllerTests;

public class SuperheroCombatServiceTests
{
    SuperheroCombatService service;

    [SetUp]
    public void Setup()
    {
        service = new();
    }

    [Test]
    public void Fight_Must_Return_CombatResult()
    {
        service.Fight("Catwoman", "Wolverine", "BankVault").Should().BeOfType(typeof(CombatResult));
    }

    [Test]
    public void GetAllNamed_Tests()
    {
        service.GetPowerstats("Batman").Count().Should().Be(2);
    }
}