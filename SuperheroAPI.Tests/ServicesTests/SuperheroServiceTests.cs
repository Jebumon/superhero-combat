using SuperheroAPI.Models;
using SuperheroAPI.Services;
using System.Collections;

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
        Hashtable combat = new();
        combat.Add("Superman", "");
        combat.Add("Wolverine", "");
        service.Fight(combat, "BankVault").Should().BeOfType(typeof(CombatResult));

        combat = new();
        combat.Add("Superman", "");
        combat.Add("Star Girl", "");
        service.Fight(combat, "BankVault").Should().BeOfType(typeof(CombatResult));

        combat = new();
        combat.Add("Superman", "");
        combat.Add("Captain Marvel", "Billy Batson");
        service.Fight(combat, "BankVault").Should().BeOfType(typeof(CombatResult));

        combat = new();
        combat.Add("Superman", "");
        combat.Add("Martian Manhunter", "");
        service.Fight(combat, "BankVault").Should().BeOfType(typeof(CombatResult));
    }

    [Test]
    public void GetAllNamed_Tests()
    {
        service.GetAllNamed("Batman").Count().Should().Be(2);
    }
}