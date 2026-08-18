using System.Threading;
using System.Threading.Tasks;
using AdsSqlApi.Application.Features.Wells.Queries;
using AdsSqlApi.Application.Abstractions.Persistence;
using MediatR;

namespace AdsSqlApi.Infrastructure.Handlers.Wells
{
    public sealed class GetWellByIdQueryHandler : IRequestHandler<GetWellByIdQuery, WellResponse?>
    {
        private readonly IRepository<Domain.Entities.Well> _repository;

        public GetWellByIdQueryHandler(IRepository<Domain.Entities.Well> repository)
        {
            _repository = repository;
        }

        public async Task<WellResponse?> Handle(GetWellByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null) return null;
            return new WellResponse
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
