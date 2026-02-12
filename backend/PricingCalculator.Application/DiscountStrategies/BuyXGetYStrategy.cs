using PricingCalculator.Domain.Entities;
using PricingCalculator.Domain.Enums;
using PricingCalculator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.Application.DiscountStrategies
{
    public class BuyXGetYStrategy : IDiscountStrategy
    {
        public DiscountType SupportedType => DiscountType.BuyXGetY;

        public decimal CalculateDiscount(
            int quantity,
            decimal unitPrice,
            DiscountRule rule)
        {
            if (!rule.BuyQuantity.HasValue || !rule.FreeQuantity.HasValue)
                return 0m;

            int groupSize = rule.BuyQuantity.Value + rule.FreeQuantity.Value;

            if (groupSize <= 0)
                return 0m;

            int eligibleGroups = quantity / groupSize;
            int freeItems = eligibleGroups * rule.FreeQuantity.Value;

            return freeItems * unitPrice;
        }
    }
}
