using Microsoft.AspNetCore.Mvc;
using SuperheroAPI.Models;
using SuperheroAPI.Services;
using System.Collections;

namespace SuperheroAPI.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class SuperheroCombatController : ControllerBase
    {
        private readonly ISuperheroCombatService _superheroCombatService;

        public SuperheroCombatController(ISuperheroCombatService superheroCombatService)
        {
            _superheroCombatService = superheroCombatService;
        }

        [HttpGet("GetSuperheroes/{name}")]
        public ActionResult<IEnumerable<Contestant>> GetAllSuperheroesNamed(string name)
        {
            var superhero = _superheroCombatService.GetAllNamed(name);
            return superhero;
        }

        [HttpGet("{battlefieldName}/{contestantName1}/{contestantName2}/{contestantRealName1?}/{contestantRealName2?}")]
        public ActionResult<CombatResult> CombatNow(string battlefieldName, string contestantName1, string contestantName2, string contestantRealName1 = "NO NEED", string contestantRealName2 = "NO NEED")
        {
            Hashtable inputNames = new();

            if (contestantRealName1 == "NO NEED")
                contestantRealName1 = " ";

            if (contestantRealName2 == "NO NEED")
                contestantRealName2 = " ";

            inputNames.Add(contestantName1, contestantRealName1);
            inputNames.Add(contestantName2, contestantRealName2);

            var results = _superheroCombatService.Fight(inputNames, battlefieldName);
            return results;
        }
    }   
}
