using PricingCalculator.Application.DTOs;
using PricingCalculator.Application.Interfaces;

namespace PricingCalculator.Api.Endpoints
{
    public static class PricingEndpoints
    {
        public static void MapPricingEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/pricing/calculate",
                async (
                    BasketRequestDto request,
                    IPricingService pricingService) =>
                {
                    var result = await pricingService.CalculateBasketAsync(request);
                    return Results.Ok(result);
                })
                .WithName("CalculateBasket");
        }
    }
}
