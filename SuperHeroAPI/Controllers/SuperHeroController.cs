using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros() {

            var result = await _superHeroService.GetAllHeros();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var result = await _superHeroService.GetSingleHero(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddSingleHero([FromBody] SuperHero superHero)
        {
            var result=await _superHeroService.AddSingleHero(superHero);
            
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateSingleHero(int id, [FromBody] SuperHero superHero)
        {
            var result=await _superHeroService.UpdateSingleHero(id, superHero);
            if (result is null)
                return NotFound("Super Hero Not found");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSingleHero(int id)
        {
            var result =await _superHeroService.DeleteSingleHero(id) ;
            
            if (result is null)
                return NotFound("Super Hero not found!!");


            return Ok(result);
        }
    }
}
