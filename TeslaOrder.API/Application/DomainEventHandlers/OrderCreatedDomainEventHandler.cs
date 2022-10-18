
using System.Threading.Tasks;
using System.Threading;
using TeslaOrder.Domain.Abstractions;
using TeslaOrder.Domain.Events;
using DotNetCore.CAP;
using TeslaOrder.API.Application.IntegrationEvents;

namespace TeslaOrder.API.Application.DomainEventHandlers
{
    /// <summary>
    /// 订单创建领域事件处理方法
    /// </summary>
    public class OrderCreatedDomainEventHandler : IDomainEventHandler<OrderCreatedDomainEvent>
    {
        /// <summary>
        /// Cap发布者
        /// </summary>
        readonly ICapPublisher _capPublisher;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="capPublisher"></param>
        public OrderCreatedDomainEventHandler(ICapPublisher capPublisher)
        {
            this._capPublisher = capPublisher;
        }

        /// <summary>
        /// 处理方法
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(OrderCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _capPublisher.PublishAsync("OrderCreated", new OrderCreatedIntegrationEvent(notification.Order.Id));
        }
    }
}
