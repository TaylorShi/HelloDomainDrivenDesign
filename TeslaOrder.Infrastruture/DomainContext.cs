using DotNetCore.CAP;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TeslaOrder.Domain.OrderAggregate;
using TeslaOrder.Domain.UserAggregate;
using TeslaOrder.Infrastructure.Core;
using TeslaOrder.Infrastruture.EntityConfigurations;

namespace TeslaOrder.Infrastruture
{
    public class DomainContext : EFContext
    {
        public DomainContext(DbContextOptions options, IMediator mediator, ICapPublisher capBus) : base(options, mediator, capBus)
        {
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 注册领域模型与数据库的映射关系
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
