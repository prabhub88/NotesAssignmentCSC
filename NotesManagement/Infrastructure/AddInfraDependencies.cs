using Application;
using Infrastructure.AutoMapper;
using Infrastructure.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class AddInfraDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NotesDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("NotesConnectionString")));

            services.AddScoped<INotesRepository,NotesRepository>();

            services.AddAutoMapper(typeof(NotesDtoToEntityProfile).Assembly);
            return services;
        }
    }
}
