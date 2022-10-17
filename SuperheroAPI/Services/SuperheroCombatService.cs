using SuperheroAPI.Models;
using SuperheroAPI.Repository;

namespace SuperheroAPI.Services
{
    public class SuperheroCombatService
    {
        private readonly SuperheroCombatRepository _repository;
        private readonly CombatHandler _combatHandler;

        public SuperheroCombatService(SuperheroCombatRepository repository)
        {
            _repository = repository;
            _combatHandler = new();
        }

        public CombatResult Fight(string contestantNameA, string contestantNameB, string battlefieldName)
        {
            Battlefield battlefield = BattlefieldList.GetBattlefield(battlefieldName);
            List<Contestant> contestants = _repository.GetContestants(contestantNameA, contestantNameB);

            return _combatHandler.Fight(contestants, battlefield);
        }
    }
}
