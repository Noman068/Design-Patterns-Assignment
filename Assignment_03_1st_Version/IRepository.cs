using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRepository<T>
{
    Task<T> GetByIdAsync(string id);
    Task<List<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(string id);
}
