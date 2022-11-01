using Microsoft.AspNetCore.Mvc;
using SuperheroAPI.Models;
using SuperheroAPI.Services;
using System.Collections;
using System.Net;

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
            try
            {
                var superhero = _superheroCombatService.GetAllNamed(name);
                return superhero;
            }
            catch
            {
                return Problem("Superhero does not exist - check spelling or case!", statusCode: (int)HttpStatusCode.NotFound);
            }
        }

        [HttpGet("{battlefieldName}/{contestantName1}/{contestantName2}/{contestantRealName1?}/{contestantRealName2?}")]
        public ActionResult<CombatResult> CombatNow(string battlefieldName, string contestantName1, string contestantName2, string contestantRealName1 = "NO NEED", string contestantRealName2 = "NO NEED")
        {
            Hashtable inputNames = new();

            if (contestantRealName1 == "NO NEED")
                contestantRealName1 = "";

            if (contestantRealName2 == "NO NEED")
                contestantRealName2 = "";

            try
            {
                inputNames.Add(contestantName1, contestantRealName1);
                inputNames.Add(contestantName2, contestantRealName2);
            }
            catch
            {
                return Problem("Contestants must be different!", statusCode: (int)HttpStatusCode.BadRequest);
            }

            try
            {
                var results = _superheroCombatService.Fight(inputNames, battlefieldName);
                return results;
            }
            catch (Exception e)
            {
                return Problem(e.ToString(), statusCode: (int)HttpStatusCode.BadRequest);
            }
        }
    }   
}
