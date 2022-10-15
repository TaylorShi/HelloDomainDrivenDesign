using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TeslaOrder.Domain.OrderAggregate;
using TeslaOrder.Domain.UserAggregate;

namespace TeslaOrder.Infrastruture.EntityConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("user");
        }
    }
}
