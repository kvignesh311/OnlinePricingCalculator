using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.Application.DTOs
{
    public class PricedItemDto
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal FinalAmount { get; set; }
    }
}
