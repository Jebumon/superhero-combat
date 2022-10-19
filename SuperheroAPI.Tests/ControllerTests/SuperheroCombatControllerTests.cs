using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SuperheroAPI.Controllers;
using SuperheroAPI.Models;
using SuperheroAPI.Services;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace SuperheroAPI.Tests.ControllerTests;

public class SuperheroCombatControllerTests
{
    private SuperheroCombatController _controller;
    private Mock<ISuperheroCombatService> _mockSuperheroCombatService;
    private string _contestantName1 = "Contestant 1";
    private string _contestantName2 = "Contestant 2";

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
        List<Contestant> testContestant = new List<Contestant>();
        testContestant.Add(new Contestant(_contestantName1, 100, 100, 100, 100, 100, 100));
        _mockSuperheroCombatService.Setup(s => s.GetPowerstats(_contestantName1)).Returns(testContestant);

        // Act
        var result = _controller.GetSuperheroPowerstats(_contestantName1);

        // Assert
        result.Should().BeOfType(typeof(ActionResult<IEnumerable<Contestant>>));
        result.Value.Should().BeEquivalentTo(testContestant);
    }

    [Test]
    public void CombatNow_Returns_A_CombatResult_With_A_Winner()
    {
        // Arrange
        CombatResult combatResult = new CombatResult(_contestantName1, WinMargin.CloseCall);
        _mockSuperheroCombatService.Setup(s => s.Fight(_contestantName1, _contestantName2, "Volcano")).Returns(combatResult);

        // Act
        var result = _controller.CombatNow(_contestantName1, _contestantName2, "Volcano");

        // Assert
        result.Value.Should().BeEquivalentTo(combatResult);
    }
}