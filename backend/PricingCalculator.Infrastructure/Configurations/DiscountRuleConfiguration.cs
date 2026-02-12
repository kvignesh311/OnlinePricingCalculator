using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PricingCalculator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.Infrastructure.Configurations
{
    public class DiscountRuleConfiguration : IEntityTypeConfiguration<DiscountRule>
    {
        public void Configure(EntityTypeBuilder<DiscountRule> builder)
        {
            builder.ToTable("DiscountRules");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Percentage)
                .HasColumnType("decimal(5,2)");

            builder.Property(r => r.BuyQuantity);

            builder.Property(r => r.FreeQuantity);
        }
    }
}
