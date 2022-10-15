using Microsoft.AspNetCore.Mvc;

namespace SuperheroAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuperheroCombatController : ControllerBase
    {
        [HttpGet("Superhero/{name}")]
        public string GetSuperheroPowerstats()
        {
            return "Powerstats to be returned";
        }

        [HttpGet("Combat/{name1}/{name2}/{battlefield}")]
        public string CombatNow()
        {
            return "The combat to begin!";
        }
    }
}