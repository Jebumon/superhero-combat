using Microsoft.AspNetCore.Mvc;
using SuperheroAPI.Controllers;
using SuperheroAPI.Models;
using SuperheroAPI.Services;

namespace SuperheroAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // think about changing this to api/v1/
    public class SuperheroCombatController : ControllerBase
    {
        private readonly SuperheroCombatService _superheroCombatService;

        public SuperheroCombatController(SuperheroCombatService superheroCombatService)
        {
            _superheroCombatService = superheroCombatService;
        }

        [HttpGet("Powerstats/{name}")]
        public ActionResult<Contestant> GetSuperheroPowerstats(string name)
        {
            var testContestant = new Contestant("Jasmine", 100, 100, 100, 100, 100, 100);
            return testContestant;
        }

        [HttpGet("Combat/{name1}/{name2}/{battlefield}")]
        public string CombatNow()
        {
            return "The combat to begin!";
        }
    }
}