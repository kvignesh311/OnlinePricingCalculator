using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PricingCalculator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.Infrastructure.Configurations
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.ToTable("Discounts");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(d => d.Type)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(d => d.IsActive)
                .IsRequired();

            builder.HasMany(d => d.Rules)
                .WithOne()
                .HasForeignKey(r => r.DiscountId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(d => d.DiscountItems)
                .WithOne()
                .HasForeignKey(di => di.DiscountId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
