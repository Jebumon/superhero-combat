using SuperheroAPI.Models;
using System.Collections;

namespace SuperheroAPI.Services
{
    public interface ISuperheroCombatService
    {
        CombatResult Fight(Hashtable contestantsNames, string battlefieldName);

        List<Contestant> GetAllNamed(string name);
    }
}
