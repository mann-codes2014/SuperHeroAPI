using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<SuperHero> GetAllHeros();

        SuperHero? GetSingleHero(int id);

        List<SuperHero> AddSingleHero([FromBody] SuperHero superHero);
        List<SuperHero>? UpdateSingleHero(int id, [FromBody] SuperHero superHero);

        List<SuperHero>? DeleteSingleHero(int id);
    }
}
