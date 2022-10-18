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
        public List<Contestant> GetAllNamed(string name)
        {
            return contestantsList;
        }
    }
}