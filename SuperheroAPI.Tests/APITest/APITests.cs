using SuperheroAPI.Controllers;
using SuperheroAPI.Models;
using SuperheroAPI.Services;
using System.Collections;

namespace SuperheroAPI.Tests.ControllerTests;

public class APITests
{
    private SuperheroCombatController controller;

    [SetUp]
    public void Setup()
    {
        controller = new(new SuperheroCombatService());
    }

    [Test]
    public void Fight_Results()
    {
        var result = controller.CombatNow("BankVault", "Batman", "Superman", "Bruce Wayne");
        result.Value.Winner.Should().Be("Superman");
        result.Value.WinMargin.Should().Be(WinMargin.NoChance);

        result = controller.CombatNow("BankVault", "Wolverine", "Superman");
        result.Value.Winner.Should().Be("Superman");
        result.Value.WinMargin.Should().Be(WinMargin.SolidWin);

        result = controller.CombatNow("BankVault", "Wolverine", "Batman", "", "Bruce Wayne");
        result.Value.Winner.Should().Be("Wolverine");
        result.Value.WinMargin.Should().Be(WinMargin.SolidWin);

        result = controller.CombatNow("BankVault", "Superman", "Cyborg Superman");
        result.Value.Winner.Should().Be("Superman");
        result.Value.WinMargin.Should().Be(WinMargin.CloseCall);

        result = controller.CombatNow("BankVault", "Flash", "Zoom");
        result.Value.Winner.Should().Be("Zoom");
        result.Value.WinMargin.Should().Be(WinMargin.CloseCall);
    }

    [Test]
    public void Error_Handling()
    {
        var result = controller.CombatNow("BankVault", "Ammo", "Superman");
        result.Value.Winner.Should().Be("Superman");
        result.Value.WinMargin.Should().Be(WinMargin.NoChance);
    }
}