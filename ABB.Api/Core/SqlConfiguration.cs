using ABB.Domain;
using ABB.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ABB.Api.Core
{
    public static class SqlConfiguration
    {
        public static void ConfigureSql(this IServiceCollection services, IConfigurationOptions configurationOptions)
        {
            var opt = new DbContextOptionsBuilder<EmployeeDbContext>();
            var connectionString = configurationOptions.SQLConnectionString;
            opt.UseSqlServer(connectionString);
            services.AddSingleton<DbContext>(new EmployeeDbContext(opt.Options));
            services.AddSingleton<ISqlDbClientFactory, SqlDbClientFactory>();
            services.AddSingleton(typeof(ISqlDbRepository<>), typeof(SqlDbRepository<>));
        }
    }
}
