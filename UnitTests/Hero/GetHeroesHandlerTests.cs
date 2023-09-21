using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerticalSliceHeroApi.Features.Heroes.Query;
using VerticalSliceHeroApi.Infrastructure;

namespace UnitTests.Hero
{
    [TestClass]
    public class GetHeroesHandlerTests
    {
        private IRequestHandler<GetHeroesQuery, GetHeroesResponse> _handler;

        [TestInitialize] 
        public void Initialize() {
            var db = new FakeDb();
            _handler = new GetHeroesHandler(db);
        }

        [TestMethod]
        public async Task GetHeroes()
        {
            var heroes = await _handler.Handle(new GetHeroesQuery(), cancellationToken: default);
            Assert.IsNotNull(heroes);
        }

        [TestMethod]
        public async Task GetHeroes_ReturnSingle()
        {
            var query = new GetHeroesQuery();
            query.Name = "Spiderman";
            var heroes = await _handler.Handle(query, cancellationToken: default);
            Assert.IsNotNull(heroes);
            Assert.AreEqual(1, heroes.Total);
        }
    }
}
