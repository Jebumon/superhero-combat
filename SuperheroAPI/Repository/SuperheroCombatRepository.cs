using Newtonsoft.Json;
using SuperheroAPI.Models;
namespace SuperheroAPI.Repository
{
    public class SuperheroCombatRepository
    {
        List<Contestant> contestantsList = new List<Contestant>();


        public List<Contestant> GetContestants(string[] names)
        {
            return contestantsList;
        }
        public List<Contestant> GetPowerstats(string name)
        {
            return contestantsList;
        }
    }
}