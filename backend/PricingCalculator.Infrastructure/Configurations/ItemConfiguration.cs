using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PricingCalculator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricingCalculator.Infrastructure.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Code)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(i => i.Code)
                .IsUnique();

            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.UnitPrice)
                .HasColumnType("decimal(18,2)");

            builder.Property(i => i.IsActive)
                .IsRequired();
        }
    }
}
