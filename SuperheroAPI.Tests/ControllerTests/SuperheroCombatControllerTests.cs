using SuperheroAPI.Controllers;
using SuperheroAPI.Models;
using SuperheroAPI.Services;
namespace SuperheroAPI.Tests.ControllerTests;

public class SuperheroCombatControllerTests
{
    private SuperheroCombatController _controller;
    private Mock<SuperheroCombatService> _mockSuperheroCombatService;

    [SetUp]
    public void Setup()
    {
        _mockSuperheroCombatService = new Mock<SuperheroCombatService>();
        _controller = new SuperheroCombatController(_mockSuperheroCombatService.Object);
    }

    [Test]
    public void GetSuperheroPowerstats_Gets_Powerstats_With_Valid_Name()
    {
        // Arrange
        //var testContestant = new Contestant("Jasmine", 100, 100, 100, 100, 100, 100);
       // _mockSuperheroCombatService.Setup(s => s.GetSuperheroPowerstats(Jasmine)).Returns(testContestant);
        Assert.Pass();
    }

    [Test]
    public void Test2()
    {
        Assert.Pass();
    }
}