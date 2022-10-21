﻿using SuperheroAPI.Models;
using SuperheroAPI.Repository;

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

        public CombatResult Fight(string contestantNameA, string contestantNameB, string battlefieldName)
        {
            Battlefield battlefield = BattlefieldList.GetBattlefield(battlefieldName);
            string[] namesArray = { contestantNameA, contestantNameB };
            List<Contestant> contestants = _repository.GetContestants(namesArray);

            return _combatHandler.DoCombat(contestants, battlefield);
        }

        public List<Contestant> GetAllNamed(string name)
        {
            return _repository.GetAllNamed(name);
        }
    }
}
