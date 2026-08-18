using System.Threading;
using System.Threading.Tasks;
using AdsSqlApi.Application.Features.Wells.Commands;
using AdsSqlApi.Application.Abstractions.Persistence;
using MediatR;

namespace AdsSqlApi.Infrastructure.Handlers.Wells
{
    public sealed class UpdateWellCommandHandler : IRequestHandler<UpdateWellCommand>
    {
        private readonly IRepository<Domain.Entities.Well> _repository;

        public UpdateWellCommandHandler(IRepository<Domain.Entities.Well> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateWellCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null) return Unit.Value;
            entity.Name = request.Name;
            entity.Code = request.Code;
            entity.IsActive = request.IsActive;
            await _repository.UpdateAsync(entity);
            return Unit.Value;
        }
    }
}
