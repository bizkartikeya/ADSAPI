using System;
using System.Threading.Tasks;
using AdsSqlApi.Application.Abstractions.Services;
using AdsSqlApi.Application.DTOs.Pads;
using AdsSqlApi.Domain.Entities;
using AdsSqlApi.Infrastructure.Persistence.Repositories;

namespace AdsSqlApi.Infrastructure.Services
{
    public sealed class PadsService : IPadsService
    {
        private readonly IRepository<Pads> _repository;

        public PadsService(IRepository<Pads> repository)
        {
            _repository = repository;
        }

        public async Task<Guid> CreateAsync(string name, string code, bool isActive)
        {
            var entity = new Pads { Id = Guid.NewGuid(), Name = name, Code = code, IsActive = isActive, CreatedAtUtc = DateTime.UtcNow };
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

        public async Task<PadsResponse?> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
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
