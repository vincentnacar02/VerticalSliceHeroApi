using AutoMapper;
using MediatR;
using VerticalSliceHeroApi.Domain;
using VerticalSliceHeroApi.Infrastructure;

namespace VerticalSliceHeroApi.Features.Heroes.Command
{
    public class AddHeroCommand : IRequest<AddHeroResponse>
    {
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
    }

    public class AddHeroHandler : IRequestHandler<AddHeroCommand, AddHeroResponse>
    {
        private readonly FakeDb _db;
        private readonly IMapper _mapper;
        public AddHeroHandler(FakeDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public Task<AddHeroResponse> Handle(AddHeroCommand request, CancellationToken cancellationToken)
        {
            var hero = _mapper.Map<Hero>(request);
            _db.Add(hero);

            var response = new AddHeroResponse();
            response.Id = hero.Id;

            return Task.FromResult(response);
        }
    }

    public class AddHeroResponse
    {
        public string? Id { get; set; }
    }
}
