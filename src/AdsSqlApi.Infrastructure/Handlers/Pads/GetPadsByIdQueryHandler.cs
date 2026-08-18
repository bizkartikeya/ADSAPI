using System.Threading;
using System.Threading.Tasks;
using AdsSqlApi.Application.Features.Pads.Queries;
using AdsSqlApi.Application.Abstractions.Persistence;
using MediatR;

namespace AdsSqlApi.Infrastructure.Handlers.Pads
{
    public sealed class GetPadsByIdQueryHandler : IRequestHandler<GetPadsByIdQuery, PadsResponse?>
    {
        private readonly IRepository<Domain.Entities.Pads> _repository;

        public GetPadsByIdQueryHandler(IRepository<Domain.Entities.Pads> repository)
        {
            _repository = repository;
        }

        public async Task<PadsResponse?> Handle(GetPadsByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null) return null;
            return new PadsResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                Code = entity.Code,
                IsActive = entity.IsActive,
                CreatedAtUtc = entity.CreatedAtUtc
            };
        }
    }
}
