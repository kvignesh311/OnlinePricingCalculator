using Microsoft.EntityFrameworkCore;
using PricingCalculator.Application.Interfaces;
using PricingCalculator.Domain.Entities;
using PricingCalculator.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly PricingDbContext _context;

        public ItemRepository(PricingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> GetActiveItemsAsync()
        {
            return await _context.Items
                .Where(i => i.IsActive)
                .ToListAsync();
        }

        public async Task<List<Item>> GetItemsByIdsAsync(IEnumerable<int> ids)
        {
            return await _context.Items
                .Where(i => ids.Contains(i.Id) && i.IsActive)
                .ToListAsync();
        }

        public async Task<List<Discount>> GetActiveDiscountsForItemsAsync(IEnumerable<int> itemIds)
        {
            return await _context.Discounts
                .Include(d => d.Rules)
                .Include(d => d.DiscountItems)
                .Where(d => d.IsActive &&
                            d.DiscountItems.Any(di => itemIds.Contains(di.ItemId)))
                .ToListAsync();
        }
    }
}
