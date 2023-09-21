using System;
using VerticalSliceHeroApi.Domain;

namespace VerticalSliceHeroApi.Infrastructure
{
    public class FakeDb
    {
        private IList<Hero> _heroes;
        public IEnumerable<Hero> Heroes { get { return _heroes.AsEnumerable(); } }
        public FakeDb() {
            _heroes = new List<Hero>();

            _heroes.Add(new Hero
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Spiderman",
                Level = 1
            });
            _heroes.Add(new Hero
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Superman",
                Level = 2
            });
            _heroes.Add(new Hero
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Wonderwoman",
                Level = 3
            });
        }

        public void Add(Hero hero)
        {
            if (string.IsNullOrEmpty(hero.Id))
            {
                hero.Id = Guid.NewGuid().ToString();
            }
            _heroes.Add(hero);
        }

        public void Update(string Id, Hero hero)
        {
            var oldHero = _heroes.FirstOrDefault(h => h.Id == Id);
            if (oldHero != null)
            {
                var index = _heroes.IndexOf(oldHero);
                _heroes[index] = hero;
            }
        }

        public void Delete(string Id)
        {
            var hero = _heroes.FirstOrDefault(h => h.Id == Id);
            if (hero != null)
            {
                _heroes.Remove(hero);
            }
        }
    }
}
