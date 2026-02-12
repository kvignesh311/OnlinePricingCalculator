using Microsoft.EntityFrameworkCore;
using PricingCalculator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PricingCalculator.Infrastructure.Data
{
    public class PricingDbContext : DbContext
    {
        public PricingDbContext(DbContextOptions<PricingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items => Set<Item>();
        public DbSet<Discount> Discounts => Set<Discount>();
        public DbSet<DiscountRule> DiscountRules => Set<DiscountRule>();
        public DbSet<DiscountItem> DiscountItems => Set<DiscountItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PricingDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
