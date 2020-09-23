using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABB.Infrastructure.Db
{
    public interface ISqlDbClient
    {
        Task<List<T>> GetAllAsync<T>() where T : class;
        Task<T> GetAsync<T>(string id) where T : class;
        Task InsertAsync<T>(T entity);
        Task DeleteAsync<T>(T entity);
    }
}
