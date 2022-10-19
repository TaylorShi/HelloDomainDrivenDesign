using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TeslaOrder.MediatorEvent
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            var services = new ServiceCollection();
            // 将MediatR添加到容器中，它会扫描我们传入的程序集
            services.AddMediatR(typeof(Program).Assembly);

            // 从容器中获取Mediator对象
            var serviceProvider = services.BuildServiceProvider();
            var mediator = serviceProvider.GetService<IMediator>();

            // 发布事件
            await mediator.Publish(new TaslaOrderEvent { EventName = "Hello Event" });

            Console.WriteLine("Hello World!");
        }
    }

    internal class TaslaOrderEvent : INotification
    {
        public string EventName { get; set; }
    }

    internal class TaslaOrderEventHandler : INotificationHandler<TaslaOrderEvent>
    {
        public Task Handle(TaslaOrderEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"TaslaOrderEventHandler : {notification.EventName}");
            return Task.FromResult(10L);
        }
    }

    internal class TaslaAddressEventHandler : INotificationHandler<TaslaOrderEvent>
    {
        public Task Handle(TaslaOrderEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"TaslaAddressEventHandler : {notification.EventName}");
            return Task.FromResult(10L);
        }
    }
}
