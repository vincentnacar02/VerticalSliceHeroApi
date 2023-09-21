using AutoMapper;
using MediatR;
using VerticalSliceHeroApi.Infrastructure;

namespace VerticalSliceHeroApi.Features.Heroes.Query
{
    public class GetHeroQuery : IRequest<GetHeroResponse>
    {
        public string Id { get; set; } = string.Empty;
    }

    public class GetHeroHandler : IRequestHandler<GetHeroQuery, GetHeroResponse>
    {
        private readonly FakeDb _db;
        private IMapper _mapper;
        public GetHeroHandler(FakeDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public Task<GetHeroResponse> Handle(GetHeroQuery request, CancellationToken cancellationToken)
        {
            var hero = _db.Heroes.Where(h => h.Id == request.Id).FirstOrDefault();
            return Task.FromResult(_mapper.Map<GetHeroResponse>(hero));
        }
    }

    public class GetHeroResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
    }
}
