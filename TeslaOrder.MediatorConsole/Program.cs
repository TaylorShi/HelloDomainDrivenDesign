using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TeslaOrder.MediatorConsole
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

            // 发送命令
            await mediator.Send(new TeslaOrderCommand { CommandName = "Hello" });

            Console.WriteLine("Hello World!");
        }
    }

    internal class TeslaOrderCommand : IRequest<long>
    {
        public string CommandName { get; set; }

        public TeslaOrderCommand()
        {

        }

        public TeslaOrderCommand(string commandName)
        {
            this.CommandName = commandName;
        }
    }

    internal class TeslaOrderCommandHandler : IRequestHandler<TeslaOrderCommand, long>
    {
        public Task<long> Handle(TeslaOrderCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"TeslaOrderCommandHandler : {request.CommandName}");
            return Task.FromResult(10L);
        }
    }

    internal class TeslaOrderCommandHandler2 : IRequestHandler<TeslaOrderCommand, long>
    {
        public Task<long> Handle(TeslaOrderCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"TeslaOrderCommandHandler2 : {request.CommandName}");
            return Task.FromResult(10L);
        }
    }
}
