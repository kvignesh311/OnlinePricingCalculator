using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.Domain.Entities
{
    public class DiscountItem
    {
        public int Id { get; private set; }

        public int DiscountId { get; private set; }

        public int ItemId { get; private set; }

        private DiscountItem() { }

        public DiscountItem(int itemId)
        {
            ItemId = itemId;
        }
    }
}
