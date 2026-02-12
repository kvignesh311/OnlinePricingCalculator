using PricingCalculator.Domain.Entities;
using PricingCalculator.Domain.Enums;
using PricingCalculator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.Application.DiscountStrategies
{
    public class PercentageStrategy : IDiscountStrategy
    {
        public DiscountType SupportedType => DiscountType.Percentage;

        public decimal CalculateDiscount(
            int quantity,
            decimal unitPrice,
            DiscountRule rule)
        {
            if (!rule.Percentage.HasValue)
                return 0m;

            decimal total = quantity * unitPrice;
            return total * (rule.Percentage.Value / 100m);
        }
    }
}
