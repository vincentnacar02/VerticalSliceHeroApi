using MediatR;
using VerticalSliceHeroApi.Infrastructure;

namespace VerticalSliceHeroApi.Features.Heroes.Command
{
    public class DeleteHeroCommand : IRequest
    {
        public string Id { get; set; } = string.Empty;
    }

    public class DeleteHeroHandler : IRequestHandler<DeleteHeroCommand>
    {
        private readonly FakeDb _db;
        public DeleteHeroHandler(FakeDb db)
        {
            _db = db;
        }
        public Task Handle(DeleteHeroCommand request, CancellationToken cancellationToken)
        {
            _db.Delete(request.Id);
            return Task.CompletedTask;
        }
    }
}
