using SuperheroAPI.Models;

namespace SuperheroAPI.Services
{
    public interface ISuperheroCombatService
    {
        CombatResult Fight(string contestantNameA, string contestantNameB, string battlefieldName);
    }
}
