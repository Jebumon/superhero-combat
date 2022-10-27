using SuperheroAPI.Models;
using System.Collections;

namespace SuperheroAPI.Repository
{
    public class SuperheroCombatRepository
    {
        public List<Contestant> GetContestants(Hashtable names)
        {
            API_handler APIhandler = new API_handler(names);
            var contestantsList = APIhandler.GetContestantsList();
            return contestantsList;
        }
        public List<Contestant> GetAllNamed(string name)
        {
            Hashtable inputName = new Hashtable();
            inputName.Add(name, "GetAllNamed");
            API_handler APIhandler = new API_handler(inputName);
            var contestantsList = APIhandler.GetContestantsList();
            return contestantsList;
        }
    }
}