using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.Application.DTOs
{
    public class BasketRequestDto
    {
        public List<BasketItemDto> Items { get; set; } = new();
    }
}
