using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.Application.DTOs
{
    public class BasketResponseDto
    {
        public List<PricedItemDto> Items { get; set; } = new();

        public decimal TotalAmount { get; set; }
    }
}
