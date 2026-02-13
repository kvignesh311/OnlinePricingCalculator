using System;
using System.Collections.Generic;
using System.Text;
using PricingCalculator.Domain.Entities;

namespace PricingCalculator.Application.Interfaces
{
    public interface IItemRepository
    {
        Task<List<Item>> GetActiveItemsAsync();

        Task<List<Item>> GetItemsByIdsAsync(IEnumerable<int> ids);

        Task<List<Discount>> GetActiveDiscountsForItemsAsync(IEnumerable<int> itemIds);
    }
}
