using SuperheroAPI.Models;
using SuperheroAPI.Repository;
using System.Collections;

namespace SuperheroAPI.Services
{
    public class SuperheroCombatService : ISuperheroCombatService
    {
        private readonly SuperheroCombatRepository _repository;
        private readonly CombatHandler _combatHandler;

        public SuperheroCombatService()
        {
            _repository = new();
            _combatHandler = new();
        }

        public CombatResult Fight(Hashtable contestantsNames, string battlefieldName)
        {
            Battlefield battlefield = BattlefieldList.GetBattlefield(battlefieldName);

            List<Contestant> contestants = _repository.GetContestants(contestantsNames);

            return _combatHandler.DoCombat(contestants, battlefield);
        }

        public List<Contestant> GetAllNamed(string name)
        {
            return _repository.GetAllNamed(name);
        }
    }
}
