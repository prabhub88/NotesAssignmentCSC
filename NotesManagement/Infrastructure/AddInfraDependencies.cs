using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class AddInfraDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Add DbContext
            services.AddDbContext<NotesDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("NotesConnectionString")));
            // Add other infrastructure services if needed
            return services;
        }
    }
}
