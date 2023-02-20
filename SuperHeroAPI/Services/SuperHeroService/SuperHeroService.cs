
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
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
        private readonly DataContext _context;

        public SuperHeroService(DataContext context)
        {
            this._context = context;
        }
        public async Task<List<SuperHero>?> AddSingleHero(SuperHero superHero)
        {
            this._context.SuperHeros.Add(superHero);
            await this._context.SaveChangesAsync();
            return await this._context.SuperHeros.ToListAsync();
        }

        public async Task<List<SuperHero>?> DeleteSingleHero(int id)
        {
            var heroToDelete = await this._context.SuperHeros.FindAsync(id);

            if (heroToDelete is null)
                return null;
            this._context.SuperHeros.Remove(heroToDelete);
            await this._context.SaveChangesAsync();
            return superHeros;
        }

        public async Task<List<SuperHero>> GetAllHeros()
        {
            var heros=await this._context.SuperHeros.ToListAsync();
            return heros;
        }

        public async Task<SuperHero?> GetSingleHero(int id)
        {
            var superHero = await this._context.SuperHeros.FindAsync(id);
            if (superHero is null)
                return null;
            return superHero;
        }

        public async Task<List<SuperHero>?> UpdateSingleHero(int id, SuperHero superHero)
        {
            var heroToUpdate = await this._context.SuperHeros.FindAsync(id);
            if (heroToUpdate is null)
                return null;
            heroToUpdate.FirstName = superHero.FirstName;
            heroToUpdate.LastName = superHero.LastName;
            heroToUpdate.Name = superHero.Name;
            heroToUpdate.Place = superHero.Place;
            await this._context.SaveChangesAsync();
            return await this._context.SuperHeros.ToListAsync();
        }
    }
}
