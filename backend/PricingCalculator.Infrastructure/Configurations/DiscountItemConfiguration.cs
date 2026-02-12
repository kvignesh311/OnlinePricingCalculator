using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PricingCalculator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.Infrastructure.Configurations
{
    public class DiscountItemConfiguration : IEntityTypeConfiguration<DiscountItem>
    {
        public void Configure(EntityTypeBuilder<DiscountItem> builder)
        {
            builder.ToTable("DiscountItems");

            builder.HasKey(di => di.Id);

            builder.HasIndex(di => new { di.DiscountId, di.ItemId })
                .IsUnique();
        }
    }
}
