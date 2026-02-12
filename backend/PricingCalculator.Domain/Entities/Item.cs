using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.Domain.Entities
{
    public class Item
    {
        public int Id { get; private set; }

        public string Code { get; private set; } = string.Empty;

        public string Name { get; private set; } = string.Empty;

        public decimal UnitPrice { get; private set; }

        public bool IsActive { get; private set; }

        private Item() { }

        public Item(string code, string name, decimal unitPrice)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Item code cannot be empty.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Item name cannot be empty.");

            if (unitPrice < 0)
                throw new ArgumentException("Unit price cannot be negative.");

            Code = code;
            Name = name;
            UnitPrice = unitPrice;
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
