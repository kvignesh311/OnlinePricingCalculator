using PricingCalculator.Application.Interfaces;
using PricingCalculator.Infrastructure.Data;

namespace PricingCalculator.Api.Endpoints
{
    public static class ItemEndpoints
    {
        public static void MapItemEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/items", async (IItemQueryService service) =>
            {
                var items = await service.GetActiveItemsAsync();

                var result = items.Select(i => new
                {
                    i.Id,
                    i.Code,
                    i.Name,
                    i.UnitPrice
                });

                return Results.Ok(result);
            });
        }
    }
}
