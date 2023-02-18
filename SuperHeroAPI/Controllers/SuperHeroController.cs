using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> superHeros = new List<SuperHero>
        {
            new SuperHero
            {
                Id=1,
                Name="Spiderman",
                FirstName="Peter",
                LastName="Parker",
                Place="NYC"
            },
            new SuperHero
            {
                Id=2,
                Name="Iron  Man",
                FirstName="Peter",
                LastName="Tony",
                Place="Pakistan"
            }

        };
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros() {
          
            return Ok(superHeros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var superHero = superHeros.Find(x => x.Id == id);
            if(superHero is null)
                return NotFound("Super Hero not found!!");
            return Ok(superHero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddSingleHero([FromBody] SuperHero superHero)
        {
            superHeros.Add(superHero);
            
            return Ok(superHeros);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateSingleHero(int id, [FromBody] SuperHero superHero)
        {
            var heroToUpdate = superHeros.Find(x => x.Id == id);
            if (heroToUpdate is null)
                return NotFound("Super Hero not found!!");
            heroToUpdate.FirstName=superHero.FirstName;
            heroToUpdate.LastName=superHero.LastName;
            heroToUpdate.Name=superHero.Name;
            heroToUpdate.Place=superHero.Place;
            return Ok(superHeros);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSingleHero(int id)
        {
            var heroToUpdate = superHeros.Find(x => x.Id == id);
            
            if (heroToUpdate is null)
                return NotFound("Super Hero not found!!");
            superHeros.Remove(heroToUpdate);
            
            return Ok(superHeros);
        }
    }
}
