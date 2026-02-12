using PricingCalculator.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.Domain.Entities
{
    public class Discount
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public DiscountType Type { get; private set; }

        public bool IsActive { get; private set; }

        public DateOnly? StartDate { get; private set; }

        public DateOnly? EndDate { get; private set; }

        private readonly List<DiscountRule> _rules = new();
        public IReadOnlyCollection<DiscountRule> Rules => _rules;

        private readonly List<DiscountItem> _discountItems = new();
        public IReadOnlyCollection<DiscountItem> DiscountItems => _discountItems;

        private Discount() { }

        public Discount(string name, DiscountType type)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Discount name cannot be empty.");

            Name = name;
            Type = type;
            IsActive = true;
        }

        public void AddRule(DiscountRule rule)
        {
            _rules.Add(rule);
        }

        public void AssignToItem(int itemId)
        {
            _discountItems.Add(new DiscountItem(itemId));
        }

        public bool IsValidToday()
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);

            if (StartDate.HasValue && today < StartDate.Value)
                return false;

            if (EndDate.HasValue && today > EndDate.Value)
                return false;

            return IsActive;
        }
    }
}
