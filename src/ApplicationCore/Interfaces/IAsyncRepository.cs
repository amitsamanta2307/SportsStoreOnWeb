using SportsStoreOnWeb.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SportsStoreOnWeb.ApplicationCore.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity<long>
    {
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    }
}