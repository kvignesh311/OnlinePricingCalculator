using PricingCalculator.Application.Interfaces;
using PricingCalculator.Domain.Entities;
using PricingCalculator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingCalculator.Application.Services
{
    public class ItemQueryService : IItemQueryService
    {
        private readonly IItemRepository _repository;

        public ItemQueryService(
            IItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Item>> GetActiveItemsAsync()
        {
            return await _repository.GetActiveItemsAsync();
        }
    }
}
