using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TeslaOrder.Domain.OrderAggregate;

namespace TeslaOrder.Infrastruture.EntityConfigurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("order");
            builder.Property(p => p.UserId).HasMaxLength(20);
            builder.Property(p => p.UserName).HasMaxLength(30);
            builder.OwnsOne(o => o.Address, a =>
            {
                a.WithOwner();
                a.Property(p => p.Province).HasColumnName("Province").HasMaxLength(50);
                a.Property(p => p.City).HasColumnName("City").HasMaxLength(30);
                a.Property(p => p.Street).HasColumnName("Street").HasMaxLength(50);
                a.Property(p => p.ZipCode).HasColumnName("ZipCode").HasMaxLength(10);
            });
        }
    }
}
