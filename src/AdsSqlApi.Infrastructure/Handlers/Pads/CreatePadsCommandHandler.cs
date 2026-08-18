using System.Threading;
using System.Threading.Tasks;
using AdsSqlApi.Application.Features.Pads.Commands;
using AdsSqlApi.Domain.Entities;
using AdsSqlApi.Infrastructure.Persistence.Repositories;
using MediatR;

namespace AdsSqlApi.Infrastructure.Handlers.Pads
{
    public sealed class CreatePadsCommandHandler : IRequestHandler<CreatePadsCommand, System.Guid>
    {
        private readonly IRepository<Pads> _repository;

        public CreatePadsCommandHandler(IRepository<Pads> repository)
        {
            _repository = repository;
        }

        public async Task<System.Guid> Handle(CreatePadsCommand request, CancellationToken cancellationToken)
        {
            var entity = new Pads { Id = System.Guid.NewGuid(), Name = request.Name, Code = request.Code, IsActive = request.IsActive, CreatedAtUtc = System.DateTime.UtcNow };
            await _repository.AddAsync(entity);
            return entity.Id;
        }
    }
}
