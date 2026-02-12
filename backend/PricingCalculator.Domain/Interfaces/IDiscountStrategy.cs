using PricingCalculator.Domain.Entities;
using PricingCalculator.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.Domain.Interfaces
{
    public interface IDiscountStrategy
    {
        DiscountType SupportedType { get; }

        decimal CalculateDiscount(
            int quantity,
            decimal unitPrice,
            DiscountRule rule);
    }
}
