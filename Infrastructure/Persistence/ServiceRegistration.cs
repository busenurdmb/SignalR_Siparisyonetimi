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
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IMoneyCaseRepository, MoneyCaseRepository>();
            services.AddScoped<IMenuTableRepository, MenuTableRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<SignalRContext>();
        }
    }
}
