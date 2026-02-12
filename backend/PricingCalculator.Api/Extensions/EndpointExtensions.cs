using PricingCalculator.Api.Endpoints;

namespace PricingCalculator.Api.Extensions
{
    public static class EndpointExtensions
    {
        public static void MapApiEndpoints(this WebApplication app)
        {
            app.MapItemEndpoints();
            app.MapPricingEndpoints();
        }
    }
}
