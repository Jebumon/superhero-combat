using Microsoft.AspNetCore.Components.Routing;
using SuperheroAPI.Models;
using SuperheroAPI.Services;
using FluentAssertions;

namespace SuperheroAPI.Tests.ServicesTests
{
    public class CombatHandlerTests
    {
        private Battlefield _battlefield;
        private CombatHandler _combatHandler;
        private CombatResult _combatResult;
        [SetUp]
        public void Setup()
        {
            _combatHandler = new();
        }

        [Test]
        public void Calculate_Correct_WinMargin_As_SolidWin_And_Winner()
        {
            List<Contestant> ContestantList = new List<Contestant>();
            ContestantList.Add(new Contestant("Batgirl", "", 88, 88, 88, 40, 34, 90));
            ContestantList.Add(new Contestant("Falcon", "", 8, 13, 50, 28, 22, 30));
            _battlefield = new Battlefield("Volcano", 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f);
            _combatResult = _combatHandler.DoCombat(ContestantList, _battlefield);
            _combatResult.WinMargin.Should().Be(WinMargin.SolidWin);
            _combatResult.Winner.Should().Be("Batgirl");
        }

        [Test]
        public void Calculate_Correct_WinMargin_As_NoChance_And_Winner()
        {
            List<Contestant> ContestantList = new List<Contestant>();
            ContestantList.Add(new Contestant("A-Bomb", "", 1, 1, 1, 1, 1, 1));
            ContestantList.Add(new Contestant("Batgirl", "", 100, 100, 100, 100, 100, 100));
            _battlefield = new Battlefield("Volcano", 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f);
            _combatResult = _combatHandler.DoCombat(ContestantList, _battlefield);
            _combatResult.WinMargin.Should().Be(WinMargin.NoChance);
            _combatResult.Winner.Should().Be("Batgirl");
        }

        [Test]
        public void Calculate_Correct_WinMargin_As_CloseCall_And_Winner()
        {
            List<Contestant> ContestantList = new List<Contestant>();
            ContestantList.Add(new Contestant("A-Bomb", "", 88, 13, 10, 38, 32, 94));
            ContestantList.Add(new Contestant("Batgirl", "", 88, 11, 33, 40, 34, 90));
            _battlefield = new Battlefield("Volcano", 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f);
            _combatResult = _combatHandler.DoCombat(ContestantList, _battlefield);
            _combatResult.WinMargin.Should().Be(WinMargin.CloseCall);
            _combatResult.Winner.Should().Be("Batgirl");
        }

        [Test]
        public void Calculate_Correct_WinMargin_As_Tie_And_Winner()
        {
            List<Contestant> ContestantList = new List<Contestant>();
            ContestantList.Add(new Contestant("Batgirl", "", 88, 11, 33, 40, 34, 90));
            ContestantList.Add(new Contestant("A-Bomb", "", 88, 11, 33, 40, 34, 90));
            _battlefield = new Battlefield("Volcano", 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f);
            _combatResult = _combatHandler.DoCombat(ContestantList, _battlefield);
            _combatResult.WinMargin.Should().Be(WinMargin.Tie);
            _combatResult.Winner.Should().Be("Both are winners");
        }
    }

}
