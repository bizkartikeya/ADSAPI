using System;
using System.Threading.Tasks;

namespace AdsSqlApi.Application.Abstractions.Services
{
    public interface IPadsService
    {
        Task<Guid> CreateAsync(string name, string code, bool isActive);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Guid id, string name, string code, bool isActive);
        Task<PadsResponse?> GetByIdAsync(Guid id);
    }
}
