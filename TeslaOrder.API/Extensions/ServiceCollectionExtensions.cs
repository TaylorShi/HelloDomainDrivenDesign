﻿using MediatR;
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

        public static IServiceCollection AddInMemoryDomainContext(this IServiceCollection services)
        {
            return services.AddDomainContext(builder => builder.UseInMemoryDatabase("domanContextDatabase"));
        }

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



        //public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddTransient<ISubscriberService, SubscriberService>();
        //    services.AddCap(options =>
        //    {
        //        options.UseEntityFramework<OrderingContext>();

        //        options.UseRabbitMQ(options =>
        //        {
        //            configuration.GetSection("RabbitMQ").Bind(options);
        //        });
        //        //options.UseDashboard();
        //    });

        //    return services;
        //}
    }
}
