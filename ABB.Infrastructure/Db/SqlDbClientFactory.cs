using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABB.Infrastructure.Db
{
    public interface ISqlDbClientFactory
    {
        ISqlDbClient Client { get; }
    }
    public class SqlDbClientFactory : ISqlDbClientFactory
    {
        private readonly DbContext _dbContext;

        public SqlDbClientFactory(DbContext dbContext)
        {
            this._dbContext = ValidateParameter(dbContext);
        }

        public ISqlDbClient Client => new SqlDbClient(_dbContext);

        private DbContext ValidateParameter(DbContext input)
        {
            if (input == null)
                throw new ArgumentException("DbContext cannot be null or empty.");
            else
                return input;
        }
    }
}
