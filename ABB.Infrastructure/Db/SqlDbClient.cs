using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABB.Infrastructure.Db
{
    public class SqlDbClient : ISqlDbClient
    {
        private readonly DbContext _dbContext;

        public SqlDbClient(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Task DeleteAsync<T>(T entity)
        {
            _dbContext.Remove(entity);
            return this._dbContext.SaveChangesAsync();
        }
        public async Task<List<T>> GetAllAsync<T>() where T : class
        {
            var query = _dbContext.Set<T>().AsQueryable();
            foreach (var property in _dbContext.Model.FindEntityType(typeof(T)).GetNavigations())
            {
                query = query.Include(property.Name);
            }
            return query.ToList();
        }
        public async Task<T> GetAsync<T>(string id) where T : class
        {
            var doc = await _dbContext.FindAsync<T>(id)
                .ConfigureAwait(false);

            return doc;
        }
        public Task InsertAsync<T>(T entity)
        {
            _dbContext.Add(entity);
            return _dbContext.SaveChangesAsync();
        }
    }
}
