using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABB.Infrastructure.Db
{
    public interface ISqlDbRepository<T> where T : class
    {
        Task DeleteAsync(T entity);
        Task<List<T>> GetAll();
        Task<T> GetAsync(string id);
        Task InsertAsync(T entity);
    }
}