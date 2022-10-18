using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TeslaOrder.API.Application.IntegrationEvents;
using TeslaOrder.Domain.OrderAggregate;
using TeslaOrder.Infrastruture;
using TeslaOrder.Infrastruture.Repositories;

namespace TeslaOrder.API.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(OrderingContextTransactionBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(DomainContextTransactionBehavior<,>));
            return services.AddMediatR(typeof(Order).Assembly, typeof(Program).Assembly);
        }


        public static IServiceCollection AddDomainContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
        {
            return services.AddDbContext<DomainContext>(optionsAction);
        }

        //public static IServiceCollection AddInMemoryDomainContext(this IServiceCollection services)
        //{
        //    return services.AddDomainContext(builder => builder.UseInMemoryDatabase("domanContextDatabase"));
        //}

        public static IServiceCollection AddMySqlDomainContext(this IServiceCollection services, string connectionString)
        {
            return services.AddDomainContext(builder =>
            {
                builder.UseMySql(connectionString);
            });
        }


        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

        /// <summary>
        /// 添加集成事件总线
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            // 先将订阅服务注入进来
            services.AddTransient<ISubscriberService, SubscriberService>();

            // 添加CAP相关的服务和配置
            services.AddCap(options =>
            {
                // 告诉框架我们是要针对DomainContext来实现我们的EventBus，EventBus和我们数据库共享数据库连接
                options.UseEntityFramework<DomainContext>();

                options.UseMySql(configuration.GetValue<string>("Mysql"));

                // 使用RabbitMQ来作为EventBus的消息队列的存储
                options.UseRabbitMQ(options =>
                {
                    configuration.GetSection("RabbitMQ").Bind(options);
                });
                //options.UseDashboard();
            });

            return services;
        }
    }
}
