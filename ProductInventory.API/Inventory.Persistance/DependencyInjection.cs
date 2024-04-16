using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Inventory.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionString"];
            services.AddDbContext<TestDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<ITestDbContext>(provider =>
                provider.GetService<TestDbContext>());
            return services;
        }
    }
}
