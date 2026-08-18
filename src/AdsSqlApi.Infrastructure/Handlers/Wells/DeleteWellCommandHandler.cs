using System.Threading;
using System.Threading.Tasks;
using AdsSqlApi.Application.Features.Wells.Commands;
using AdsSqlApi.Application.Abstractions.Persistence;
using MediatR;

namespace AdsSqlApi.Infrastructure.Handlers.Wells
{
    public sealed class DeleteWellCommandHandler : IRequestHandler<DeleteWellCommand, Unit>
    {
        private readonly IRepository<Domain.Entities.Well> _repository;

        public DeleteWellCommandHandler(IRepository<Domain.Entities.Well> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteWellCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
