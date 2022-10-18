using DotNetCore.CAP;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeslaOrder.Domain.OrderAggregate;
using TeslaOrder.Domain.UserAggregate;
using TeslaOrder.Infrastructure.Core;
using TeslaOrder.Infrastruture.EntityConfigurations;

namespace TeslaOrder.Infrastruture
{
    /// <summary>
    /// 领域上下文
    /// </summary>
    public class DomainContext : EFContext
    {
        public DomainContext(DbContextOptions options, IMediator mediator, ICapPublisher capPublisher) : base(options, mediator, capPublisher)
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
