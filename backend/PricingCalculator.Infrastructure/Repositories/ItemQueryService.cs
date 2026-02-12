using PricingCalculator.Application.Interfaces;
using PricingCalculator.Domain.Entities;
using PricingCalculator.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PricingCalculator.Infrastructure.Repositories
{
    public class ItemQueryService : IItemQueryService
    {
        private readonly PricingDbContext _context;

        public ItemQueryService(PricingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> GetActiveItemsAsync()
        {
            return await _context.Items
                .Where(i => i.IsActive)
                .ToListAsync();
        }
    }
}
