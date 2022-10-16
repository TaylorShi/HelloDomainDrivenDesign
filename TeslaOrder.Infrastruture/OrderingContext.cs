using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TeslaOrder.Domain.OrderAggregate;
using TeslaOrder.Infrastructure.Core;
using TeslaOrder.Infrastruture.EntityConfigurations;

namespace TeslaOrder.Infrastruture
{
    public class OrderingContext : EFContext
    {
        public OrderingContext(DbContextOptions options, IMediator mediator) : base(options, mediator)
        {
        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 注册领域模型与数据库的映射关系
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
