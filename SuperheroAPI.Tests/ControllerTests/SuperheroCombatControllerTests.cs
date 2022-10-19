using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SuperheroAPI.Controllers;
using SuperheroAPI.Models;
using SuperheroAPI.Services;
namespace SuperheroAPI.Tests.ControllerTests;

public class SuperheroCombatControllerTests
{
    private SuperheroCombatController _controller;
    private Mock<ISuperheroCombatService> _mockSuperheroCombatService;

    [SetUp]
    public void Setup()
    {
        _mockSuperheroCombatService = new Mock<ISuperheroCombatService>();
        _controller = new SuperheroCombatController(_mockSuperheroCombatService.Object);
    }

    [Test]
    public void GetSuperheroPowerstats_Gets_Powerstats_With_Valid_Name()
    {
        // Arrange
        string testName = "Superman";
        List<Contestant> testContestant = new List<Contestant>();
        testContestant.Add(new Contestant(testName, 100, 100, 100, 100, 100, 100));
        _mockSuperheroCombatService.Setup(s => s.GetPowerstats(testName)).Returns(testContestant);

        // Act
        var result = _controller.GetSuperheroPowerstats(testName);

        // Assert
        result.Should().BeOfType(typeof(ActionResult<IEnumerable<Contestant>>));
        result.Value.Should().BeEquivalentTo(testContestant);
    }

    [Test]
    public void Test2()
    {
        Assert.Pass();
    }
}