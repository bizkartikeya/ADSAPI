using System;
using System.Threading.Tasks;
using AdsSqlApi.Application.Abstractions.Services;
using AdsSqlApi.Application.Features.Wells.Queries;
using AdsSqlApi.Domain.Entities;
using AdsSqlApi.Infrastructure.Persistence.Repositories;

namespace AdsSqlApi.Infrastructure.Services
{
    public sealed class WellService : IWellService
    {
        private readonly IRepository<Well> _repository;

        public WellService(IRepository<Well> repository)
        {
            _repository = repository;
        }

        public async Task<Guid> CreateAsync(string name, string code, bool isActive)
        {
            var entity = new Well { Id = Guid.NewGuid(), Name = name, Code = code, IsActive = isActive, CreatedAtUtc = DateTime.UtcNow };
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task UpdateAsync(Guid id, string name, string code, bool isActive)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return;
            entity.Name = name;
            entity.Code = code;
            entity.IsActive = isActive;
            await _repository.UpdateAsync(entity);
        }

        public async Task<WellResponse?> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
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
