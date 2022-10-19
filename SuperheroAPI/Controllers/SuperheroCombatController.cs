using Microsoft.AspNetCore.Mvc;
using SuperheroAPI.Models;
using SuperheroAPI.Services;

namespace SuperheroAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // think about changing this to api/v1/
    public class SuperheroCombatController : ControllerBase
    {
        private readonly ISuperheroCombatService _superheroCombatService;

        public SuperheroCombatController(ISuperheroCombatService superheroCombatService)
        {
            _superheroCombatService = superheroCombatService;
        }

        [HttpGet("Powerstats/{name}")]
        public ActionResult<IEnumerable<Contestant>> GetSuperheroPowerstats(string name)
        {
            var superhero = _superheroCombatService.GetPowerstats(name);
            return superhero;
        }

        [HttpGet("Combat/{contestantName1}/{contestantName2}/{battlefieldName}")]
        public ActionResult<CombatResult> CombatNow(string contestantName1, string contestantName2, string battlefieldName)
        {
            var results = _superheroCombatService.Fight(contestantName1, contestantName2, battlefieldName);
            return results;
        }
    }
}
