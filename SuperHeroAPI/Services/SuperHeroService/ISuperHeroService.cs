using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>?> GetAllHeros();

        Task<SuperHero?> GetSingleHero(int id);

        Task<List<SuperHero>?> AddSingleHero([FromBody] SuperHero superHero);
        Task<List<SuperHero>?> UpdateSingleHero(int id, [FromBody] SuperHero superHero);

        Task<List<SuperHero>?> DeleteSingleHero(int id);
    }
}
