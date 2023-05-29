using ExtratoSalarial.Core.Seedwork;

namespace ExtratoSalarial.Core.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task CreateAsync(T entity);
        Task UpdateAsync(string id, T entity);
        Task DeleteAsync(string id);
    }
}
