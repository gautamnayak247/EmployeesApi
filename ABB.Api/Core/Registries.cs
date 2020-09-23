using ABB.Domain;
using ABB.Domain.Interfaces;
using ABB.Infrastructure.Db;
using Microsoft.Extensions.DependencyInjection;

namespace ABB.Api.Core
{
    public static class Registries
    {
        public static void ConfigureRegistries(this IServiceCollection services, IConfigurationOptions configurationOptions)
        {
            services.AddSingleton<IABBLogger, ABBLogger>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddSingleton<IConfigurationOptions>(configurationOptions);
        }
    }
}
