using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.Domain.Entities
{
    public class DiscountRule
    {
        public int Id { get; private set; }

        public int DiscountId { get; private set; }

        // Percentage rule
        public decimal? Percentage { get; private set; }

        // Buy X Get Y rule
        public int? BuyQuantity { get; private set; }
        public int? FreeQuantity { get; private set; }

        private DiscountRule() { }

        public static DiscountRule CreatePercentageRule(decimal percentage)
        {
            if (percentage <= 0 || percentage > 100)
                throw new ArgumentException("Percentage must be between 0 and 100.");

            return new DiscountRule
            {
                Percentage = percentage
            };
        }

        public static DiscountRule CreateBuyXGetYRule(int buyQty, int freeQty)
        {
            if (buyQty <= 0)
                throw new ArgumentException("Buy quantity must be greater than zero.");

            if (freeQty <= 0)
                throw new ArgumentException("Free quantity must be greater than zero.");

            return new DiscountRule
            {
                BuyQuantity = buyQty,
                FreeQuantity = freeQty
            };
        }
    }
}
