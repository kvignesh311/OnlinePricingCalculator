using PricingCalculator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.Application.Interfaces
{
    public interface IItemQueryService
    {
        Task<List<Item>> GetActiveItemsAsync();
    }
}
