using PricingCalculator.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.Application.Interfaces
{
    public interface IPricingService
    {
        Task<BasketResponseDto> CalculateBasketAsync(BasketRequestDto request);
    }
}
