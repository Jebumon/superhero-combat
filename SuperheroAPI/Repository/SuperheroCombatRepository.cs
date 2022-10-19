using Newtonsoft.Json;
using SuperheroAPI.Models;

namespace SuperheroAPI.Repository
{
    public class SuperheroCombatRepository
    {
        List<Contestant> contestantsList = new List<Contestant>();


        public List<Contestant> GetContestants(string[] names)
        {
            API_handler APIhandler = new API_handler(names);
            var contestantsList = APIhandler.GetContestantsList();
            return contestantsList;
        }
        public List<Contestant> GetAllNamed(string name)
        {
            return contestantsList;
        }
    }
}