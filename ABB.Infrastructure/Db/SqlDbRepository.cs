using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABB.Infrastructure.Db
{
    public class SqlDbRepository<T> : ISqlDbRepository<T> where T : class
    {
        private readonly ISqlDbClientFactory _sqlDbClientFactory;
        private const string entityNullErrorMessage = "Entity Cannot be null";
        public SqlDbRepository(ISqlDbClientFactory sqlDbClientFactory)
        {
            _sqlDbClientFactory = sqlDbClientFactory;
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(nameof(entity), entityNullErrorMessage);
            }

            var sqlClient = _sqlDbClientFactory.Client;
            await sqlClient.DeleteAsync(entity);
        }

        public async Task<T> GetAsync(string id)
        {
            var sqlClient = _sqlDbClientFactory.Client;
            return await sqlClient.GetAsync<T>(id).ConfigureAwait(false);
        }

        public async Task InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(nameof(entity), entityNullErrorMessage);
            }

            var sqlClient = _sqlDbClientFactory.Client;
            await sqlClient.InsertAsync(entity);
        }
        public async Task<List<T>> GetAll()
        {
            var sqlClient = _sqlDbClientFactory.Client;
            return await sqlClient.GetAllAsync<T>();
        }
    }
}
