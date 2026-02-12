using PricingCalculator.Application.DTOs;
using PricingCalculator.Application.Interfaces;
using PricingCalculator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.Application.Services
{
    public class PricingService : IPricingService
    {
        private readonly IItemRepository _repository;
        private readonly IEnumerable<IDiscountStrategy> _strategies;

        public PricingService(
            IItemRepository repository,
            IEnumerable<IDiscountStrategy> strategies)
        {
            _repository = repository;
            _strategies = strategies;
        }

        public async Task<BasketResponseDto> CalculateBasketAsync(BasketRequestDto request)
        {
            if (request.Items == null || !request.Items.Any())
                return new BasketResponseDto();

            var itemIds = request.Items.Select(i => i.ItemId).Distinct();

            var items = await _repository.GetItemsByIdsAsync(itemIds);
            var discounts = await _repository.GetActiveDiscountsForItemsAsync(itemIds);

            var response = new BasketResponseDto();

            foreach (var basketItem in request.Items)
            {
                var item = items.First(x => x.Id == basketItem.ItemId);

                decimal baseAmount = item.UnitPrice * basketItem.Quantity;
                decimal totalDiscount = 0m;

                var applicableDiscounts = discounts
                    .Where(d => d.DiscountItems.Any(di => di.ItemId == item.Id))
                    .Where(d => d.IsValidToday());

                decimal maxDiscount = 0m;

                foreach (var discount in applicableDiscounts)
                {
                    var strategy = _strategies
                        .FirstOrDefault(s => s.SupportedType == discount.Type);

                    if (strategy == null)
                        continue;

                    foreach (var rule in discount.Rules)
                    {
                        var calculated = strategy.CalculateDiscount(
                            basketItem.Quantity,
                            item.UnitPrice,
                            rule);

                        if (calculated > maxDiscount)
                            maxDiscount = calculated;
                    }
                }

                totalDiscount = maxDiscount;

                response.Items.Add(new PricedItemDto
                {
                    ItemId = item.Id,
                    ItemName = item.Name,
                    Quantity = basketItem.Quantity,
                    UnitPrice = item.UnitPrice,
                    DiscountAmount = totalDiscount,
                    FinalAmount = baseAmount - totalDiscount
                });
            }

            response.TotalAmount = response.Items.Sum(i => i.FinalAmount);

            return response;
        }
    }
}
