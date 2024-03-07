using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repository;


namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            //services.AddDbContext<SignalRContext>(opt =>
            //{
            //    opt.UseSqlServer(configuration.GetConnectionString("Local"));
            //});
            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<SignalRContext>();
        }
    }
}
