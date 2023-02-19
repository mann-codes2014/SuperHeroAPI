
using Microsoft.AspNetCore.Mvc;

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
        public List<SuperHero> AddSingleHero(SuperHero superHero)
        {
            superHeros.Add(superHero);

            return superHeros;
        }

        public List<SuperHero>? DeleteSingleHero(int id)
        {
            var heroToUpdate = superHeros.Find(x => x.Id == id);

            if (heroToUpdate is null)
                return null;
            superHeros.Remove(heroToUpdate);

            return superHeros;
        }

        public List<SuperHero> GetAllHeros()
        {
            return superHeros;
        }

        public SuperHero? GetSingleHero(int id)
        {
            var superHero = superHeros.Find(x => x.Id == id);
            if (superHero is null)
                return null;
            return superHero;
        }

        public List<SuperHero>? UpdateSingleHero(int id, SuperHero superHero)
        {
            var heroToUpdate = superHeros.Find(x => x.Id == id);
            if (heroToUpdate is null)
                return null;
            heroToUpdate.FirstName = superHero.FirstName;
            heroToUpdate.LastName = superHero.LastName;
            heroToUpdate.Name = superHero.Name;
            heroToUpdate.Place = superHero.Place;
            return superHeros;
        }
    }
}
