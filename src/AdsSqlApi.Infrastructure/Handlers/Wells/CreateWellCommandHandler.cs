using System;
using System.Threading;
using System.Threading.Tasks;
using AdsSqlApi.Application.Features.Wells.Commands;
using AdsSqlApi.Domain.Entities;
using AdsSqlApi.Application.Abstractions.Persistence;
using MediatR;

namespace AdsSqlApi.Infrastructure.Handlers.Wells
{
    public sealed class CreateWellCommandHandler : IRequestHandler<CreateWellCommand, System.Guid>
    {
        private readonly IRepository<Well> _repository;

        public CreateWellCommandHandler(IRepository<Well> repository)
        {
            _repository = repository;
        }

        public async Task<System.Guid> Handle(CreateWellCommand request, CancellationToken cancellationToken)
        {
            var entity = new Well { Id = System.Guid.NewGuid(), Name = request.Name, Code = request.Code, IsActive = request.IsActive, CreatedAtUtc = System.DateTime.UtcNow };
            await _repository.AddAsync(entity);
            return entity.Id;
        }
    }
}
