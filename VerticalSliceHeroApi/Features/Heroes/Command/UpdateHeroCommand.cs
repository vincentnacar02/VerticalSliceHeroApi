using AutoMapper;
using MediatR;
using VerticalSliceHeroApi.Domain;
using VerticalSliceHeroApi.Infrastructure;

namespace VerticalSliceHeroApi.Features.Heroes.Command
{
    public class UpdateHeroCommand : IRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
    }

    public class UpdateHeroHandler : IRequestHandler<UpdateHeroCommand>
    {
        private readonly FakeDb _db;
        private readonly IMapper _mapper;
        public UpdateHeroHandler(FakeDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public Task Handle(UpdateHeroCommand request, CancellationToken cancellationToken)
        {
            var hero = _mapper.Map<Hero>(request);
            _db.Update(request.Id, hero);
            return Task.CompletedTask;
        }
    }
}
