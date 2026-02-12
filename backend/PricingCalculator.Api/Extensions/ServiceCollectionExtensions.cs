using Microsoft.EntityFrameworkCore;
using PricingCalculator.Application.DiscountStrategies;
using PricingCalculator.Application.Interfaces;
using PricingCalculator.Application.Services;
using PricingCalculator.Domain.Interfaces;
using PricingCalculator.Infrastructure.Data;
using PricingCalculator.Infrastructure.Repositories;

namespace PricingCalculator.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPricingService, PricingService>();
            services.AddScoped<IItemQueryService, ItemQueryService>();

            services.AddScoped<IDiscountStrategy, BuyXGetYStrategy>();
            services.AddScoped<IDiscountStrategy, PercentageStrategy>();

            return services;
        }

        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<PricingDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IItemRepository, ItemRepository>();

            return services;
        }
    }
}
