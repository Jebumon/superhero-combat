using SuperheroAPI.Models;
using System.Collections;

namespace SuperheroAPI.Repository
{
    public class SuperheroCombatRepository
    {
        public List<Contestant> GetContestants(Hashtable names)
        {
            string[] placeholder = { "", "" };
            API_handler APIhandler = new API_handler(placeholder);
            var contestantsList = APIhandler.GetContestantsList();
            return contestantsList;
        }
        public List<Contestant> GetAllNamed(string name)
        {
            string[] singleName =  {name};
            API_handler APIhandler = new API_handler(singleName);
            var contestantsList = APIhandler.GetContestantsList();
            return contestantsList;
        }
    }
}