using MediatR;
using VerticalSliceHeroApi.Domain;
using VerticalSliceHeroApi.Infrastructure;

namespace VerticalSliceHeroApi.Features.Heroes.Query
{
    public class GetHeroesQuery : IRequest<GetHeroesResponse>
    {
        public string? Name { get; set; }
    }

    public class GetHeroesHandler : IRequestHandler<GetHeroesQuery, GetHeroesResponse>
    {
        private readonly FakeDb _db;
        public GetHeroesHandler(FakeDb db) { 
            _db = db;
        }

        public Task<GetHeroesResponse> Handle(GetHeroesQuery request, CancellationToken cancellationToken)
        {
            var response = new GetHeroesResponse();
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                response.Heroes = _db.Heroes.Where(h => h.Name == request.Name).ToList();
            } else
            {
                response.Heroes = _db.Heroes;
            }
            response.Total = response.Heroes.Count();
            return Task.FromResult(response);
        }
    }

    public class GetHeroesResponse
    {
        public IEnumerable<Hero>? Heroes { get; set; }
        public int Total { get; set; }
    }
}
