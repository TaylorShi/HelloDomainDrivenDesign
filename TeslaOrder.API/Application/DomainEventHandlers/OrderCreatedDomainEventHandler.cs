
using System.Threading.Tasks;
using System.Threading;
using TeslaOrder.Domain.Abstractions;
using TeslaOrder.Domain.Events;

namespace TeslaOrder.API.Application.DomainEventHandlers
{
    /// <summary>
    /// 订单创建领域事件处理方法
    /// </summary>
    public class OrderCreatedDomainEventHandler : IDomainEventHandler<OrderCreatedDomainEvent>
    {
        /// <summary>
        /// 处理方法
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task Handle(OrderCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
