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
        combat.Add("Spider-man", "");
        service.Fight(combat, "BankVault").Should().BeOfType(typeof(CombatResult));
    }

    [Test]
    public void GetAllNamed_Tests()
    {
        service.GetAllNamed("Batman").Count().Should().Be(2);
    }
}